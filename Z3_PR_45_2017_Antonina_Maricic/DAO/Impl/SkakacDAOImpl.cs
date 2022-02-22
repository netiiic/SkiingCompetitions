using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Z3_PR_45_2017_Antonina_Maricic.Connection;
using Z3_PR_45_2017_Antonina_Maricic.Model;
using Z3_PR_45_2017_Antonina_Maricic.Utils;

namespace Z3_PR_45_2017_Antonina_Maricic.DAO.Impl
{
    public class SkakacDAOImpl : ISkakacDAO
    {
        public int Count()
        {
            string query = "select count(*) from skakac";

            using (IDbConnection connection = ConnectionUtil_Pooling.GetConnection())
            {
                connection.Open();
                using (IDbCommand command = connection.CreateCommand())
                {
                    command.CommandText = query;
                    command.Prepare();

                    return Convert.ToInt32(command.ExecuteScalar());
                }
            }
        }

        public int Delete(Skakac entity)
        {
            return DeleteById(entity.IdSC);
        }

        public int DeleteAll()
        {
            string query = "delete from skakac";

            using (IDbConnection connection = ConnectionUtil_Pooling.GetConnection())
            {
                connection.Open();
                using (IDbCommand command = connection.CreateCommand())
                {
                    command.CommandText = query;
                    command.Prepare();
                    return command.ExecuteNonQuery();
                }
            }
        }

        public int DeleteById(int id)
        {
            string query = "delete from skakac where idsc=:idsc";

            using (IDbConnection connection = ConnectionUtil_Pooling.GetConnection())
            {
                connection.Open();
                using (IDbCommand command = connection.CreateCommand())
                {
                    command.CommandText = query;
                    ParameterUtil.AddParameter(command, "idsc", DbType.Int32);
                    command.Prepare();
                    ParameterUtil.SetParameterValue(command, "idsc", id);
                    return command.ExecuteNonQuery();
                }
            }
        }

        public bool ExistsById(int id)
        {
            using (IDbConnection connection = ConnectionUtil_Pooling.GetConnection())
            {
                connection.Open();
                return ExistsById(id, connection);
            }
        }

        private bool ExistsById(int id, IDbConnection connection)
        {
            string query = "select * from skakac where idsc=:idsc";

            using (IDbCommand command = connection.CreateCommand())
            {
                command.CommandText = query;
                ParameterUtil.AddParameter(command, "idsc", DbType.Int32);
                command.Prepare();
                ParameterUtil.SetParameterValue(command, "idsc", id);
                return command.ExecuteScalar() != null;
            }
        }

        public IEnumerable<Skakac> FindAll()
        {
            string query = "select idsc, imesc, przsc, idd, titule, pbsc from skakac";
            List<Skakac> skakacList = new List<Skakac>();

            using (IDbConnection connection = ConnectionUtil_Pooling.GetConnection())
            {
                connection.Open();
                using (IDbCommand command = connection.CreateCommand())
                {
                    command.CommandText = query;
                    command.Prepare();

                    using (IDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Skakac skakac = new Skakac(reader.GetInt32(0), reader.GetString(1), reader.GetString(2),
                                reader.GetString(3), reader.GetInt32(4), reader.GetFloat(5));
                            skakacList.Add(skakac);
                        }
                    }
                }
            }

            return skakacList;
        }

        public IEnumerable<Skakac> FindAllById(IEnumerable<int> ids)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("select idsc, imesc, przsc, idd, titule, pbsc from skakac where idsc in (");
            foreach (int id in ids)
            {
                sb.Append(":id" + id + ",");
            }
            sb.Remove(sb.Length - 1, 1); // delete last ','
            sb.Append(")");

            List<Skakac> skakacList = new List<Skakac>();

            using (IDbConnection connection = ConnectionUtil_Pooling.GetConnection())
            {
                connection.Open();
                using (IDbCommand command = connection.CreateCommand())
                {
                    command.CommandText = sb.ToString();
                    foreach (int id in ids)
                    {
                        ParameterUtil.AddParameter(command, "id" + id, DbType.Int32);
                    }
                    command.Prepare();

                    foreach (int id in ids)
                    {
                        ParameterUtil.SetParameterValue(command, "id" + id, id);
                    }
                    using (IDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Skakac skakac = new Skakac(reader.GetInt32(0), reader.GetString(1), reader.GetString(2),
                                reader.GetString(3), reader.GetInt32(4), reader.GetFloat(5));
                            skakacList.Add(skakac);
                        }
                    }
                }
            }

            return skakacList;
        }

        public Skakac FindById(int id)
        {
            string query = "select idsc, imesc, przsc, idd, titule, pbsc " +
                        "from skakac where idsc = :idsc";
            Skakac skakac = null;

            using (IDbConnection connection = ConnectionUtil_Pooling.GetConnection())
            {
                connection.Open();
                using (IDbCommand command = connection.CreateCommand())
                {
                    command.CommandText = query;
                    ParameterUtil.AddParameter(command, "idsc", DbType.Int32);
                    command.Prepare();
                    ParameterUtil.SetParameterValue(command, "idsc", id);
                    using (IDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            skakac = new Skakac(reader.GetInt32(0), reader.GetString(1), reader.GetString(2),
                                reader.GetString(3), reader.GetInt32(4), reader.GetFloat(5));
                        }
                    }
                }
            }

            return skakac;
        }

        public int Save(Skakac entity)
        {
            using (IDbConnection connection = ConnectionUtil_Pooling.GetConnection())
            {
                connection.Open();
                return Save(entity, connection);
            }
        }

        // used by save and saveAll
        private int Save(Skakac skakac, IDbConnection connection)
        {
            // id_th intentionally in the last place, so that the order between commands remains the same
            string insertSql = "insert into skakac (imesc, przsc, idd, titule, pbsc, idsc) " +
                "values (:imesc, :przsc , :idd, :titule, :pbsc, :idsc)";
            string updateSql = "update skakac set imesc=:imesc, przsc=:przsc, " +
                "idd=:idd, titule=:titule, pbsc=:pbsc where idsc=:idsc";
            using (IDbCommand command = connection.CreateCommand())
            {
                command.CommandText = ExistsById(skakac.IdSC, connection) ? updateSql : insertSql;
                ParameterUtil.AddParameter(command, "imesc", DbType.String, 50);
                ParameterUtil.AddParameter(command, "przsc", DbType.String, 50);
                ParameterUtil.AddParameter(command, "idd", DbType.String, 50);
                ParameterUtil.AddParameter(command, "titule", DbType.Int32);
                ParameterUtil.AddParameter(command, "pbsc", DbType.Decimal);
                ParameterUtil.AddParameter(command, "idsc", DbType.Int32);
                command.Prepare();
                ParameterUtil.SetParameterValue(command, "idsc", skakac.IdSC);
                ParameterUtil.SetParameterValue(command, "imesc", skakac.ImeSC);
                ParameterUtil.SetParameterValue(command, "przsc", skakac.PrzSC);
                ParameterUtil.SetParameterValue(command, "idd", skakac.IDD);
                ParameterUtil.SetParameterValue(command, "titule", skakac.Titule);
                ParameterUtil.SetParameterValue(command, "pbsc", skakac.PbSC);
                return command.ExecuteNonQuery();
            }
        }

        public int SaveAll(IEnumerable<Skakac> entities)
        {
            using (IDbConnection connection = ConnectionUtil_Pooling.GetConnection())
            {
                connection.Open();
                IDbTransaction transaction = connection.BeginTransaction(); // transaction start

                int numSaved = 0;

                // insert or update every theatre
                foreach (Skakac entity in entities)
                {
                    // changes are visible only to current connection
                    numSaved += Save(entity, connection);
                }

                // transaction ends successfully, changes are now visible to other connections as well
                transaction.Commit();

                return numSaved;
            }
        }
    }
}
