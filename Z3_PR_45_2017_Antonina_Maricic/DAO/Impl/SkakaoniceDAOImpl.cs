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
    public class SkakaoniceDAOImpl : ISkakaoniceDAO
    {
        public List<Skakaonica> Type(string tip)
        {
            string query = "select * " +
                            "from skakaonica where tipsa = :tipsa";
            List<Skakaonica> skakaonicaList = new List<Skakaonica>();

            using (IDbConnection connection = ConnectionUtil_Pooling.GetConnection())
            {
                connection.Open();
                using (IDbCommand command = connection.CreateCommand())
                {
                    command.CommandText = query;
                    ParameterUtil.AddParameter(command, "tipsa", DbType.String);
                    command.Prepare();
                    ParameterUtil.SetParameterValue(command, "tipsa", tip);

                    using (IDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Skakaonica s = new Skakaonica(reader.GetString(0), reader.GetString(1), reader.GetInt32(2), reader.GetString(3), reader.GetString(4));
                            skakaonicaList.Add(s);
                        }
                    }
                }
            }

            return skakaonicaList;
        }

        public decimal AVGLenght(string tip)
        {
            string query = "select avg(duzinasa) from skakaonica where tipsa = :tipsa";

            using (IDbConnection connection = ConnectionUtil_Pooling.GetConnection())
            {
                connection.Open();
                using (IDbCommand command = connection.CreateCommand())
                {
                    command.CommandText = query;
                    ParameterUtil.AddParameter(command, "tipsa", DbType.String);
                    command.Prepare();
                    ParameterUtil.SetParameterValue(command, "tipsa", tip);

                    object result = command.ExecuteScalar();
                    if (result == null) return -1;
                    return Convert.ToDecimal(result);
                }
            }
        }



        public int Count()
        {
            string query = "select count(*) from skakaonica";

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

        public int Delete(Skakaonica entity)
        {
            throw new NotImplementedException();
        }

        public int DeleteAll()
        {
            throw new NotImplementedException();
        }

        public int DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public bool ExistsById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Skakaonica> FindAll()
        {
            string query = "select idsa, nazivsa, duzinasa, tipsa, idd from skakaonica";
            List<Skakaonica> skakaonicaList = new List<Skakaonica>();

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
                            Skakaonica skakac = new Skakaonica(reader.GetString(0), reader.GetString(1), reader.GetInt32(2),
                                reader.GetString(3), reader.GetString(4));
                            skakaonicaList.Add(skakac);
                        }
                    }
                }
            }

            return skakaonicaList;
        }

        public IEnumerable<Skakaonica> FindAllById(IEnumerable<int> ids)
        {
            throw new NotImplementedException();
        }

        public Skakaonica FindById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Skok> SkokList (string tipsa)
        {
            string query = "select s.idsk, s.idsc, s.idsa, s.bduzina, s.bstil, s.bvetar " +
                            "from skok s, skakaonica sa where s.idsa = sa.idsa and sa.tipsa = :tipsa";
            List<Skok> skokList = new List<Skok>();

            using (IDbConnection connection = ConnectionUtil_Pooling.GetConnection())
            {
                connection.Open();
                using (IDbCommand command = connection.CreateCommand())
                {
                    command.CommandText = query;
                    ParameterUtil.AddParameter(command, "tipsa", DbType.String);
                    command.Prepare();
                    ParameterUtil.SetParameterValue(command, "tipsa", tipsa);

                    using (IDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Skok skok = new Skok(reader.GetString(0), reader.GetInt32(1), reader.GetString(2), reader.GetFloat(3),
                                reader.GetFloat(4), reader.GetInt32(5));
                            skokList.Add(skok);
                        }
                    }
                }
            }

            return skokList;
        }

        public int Razlicit(string tipsa)
        {
            string query = "select count (distinct idsc) from skok s, skakaonica sk " +
                            "where s.idsa = sk.idsa and sk.tipsa = :tipsa";

            using (IDbConnection connection = ConnectionUtil_Pooling.GetConnection())
            {
                connection.Open();
                using (IDbCommand command = connection.CreateCommand())
                {
                    command.CommandText = query;
                    ParameterUtil.AddParameter(command, "tipsa", DbType.String);
                    command.Prepare();
                    ParameterUtil.SetParameterValue(command, "tipsa", tipsa);

                    object result = command.ExecuteScalar();
                    if (result == null) return -1;
                    return Convert.ToInt32(result);
                }
            }
        }       

        public int Save(Skakaonica entity)
        {
            throw new NotImplementedException();
        }

        public int SaveAll(IEnumerable<Skakaonica> entities)
        {
            throw new NotImplementedException();
        }  

        public int Ukupan(string tipsa)
        {
            string query = "select count(*) from skok s, skakaonica sk " +
                            "where s.idsa = sk.idsa and sk.tipsa = :tipsa";

            using (IDbConnection connection = ConnectionUtil_Pooling.GetConnection())
            {
                connection.Open();
                using (IDbCommand command = connection.CreateCommand())
                {
                    command.CommandText = query;
                    ParameterUtil.AddParameter(command, "tipsa", DbType.String);
                    command.Prepare();
                    ParameterUtil.SetParameterValue(command, "tipsa", tipsa);

                    object result = command.ExecuteScalar();
                    if (result == null) return -1;
                    return Convert.ToInt32(result);
                }
            }
        }         
    }
}
