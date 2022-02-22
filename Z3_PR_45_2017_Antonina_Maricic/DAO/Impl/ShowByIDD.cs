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
    public class ShowByIDD : IShowByIDDDAO
    {
        public int Count()
        {
            throw new NotImplementedException();
        }

        public int Delete(Skakac entity)
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

        public IEnumerable<Skakac> FindAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Skakac> FindAllById(IEnumerable<int> ids)
        {
            throw new NotImplementedException();
        }

        public Skakac FindById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Skakac> FindByIDD(string idd)
        {
            string query = "select idsc, imesc, przsc, idd, titule, pbsc " +
                        "from skakac where idd = :idd";
            Skakac skakac = null;
            List<Skakac> result = new List<Skakac>();
            using (IDbConnection connection = ConnectionUtil_Pooling.GetConnection())
            {
                connection.Open();
                using (IDbCommand command = connection.CreateCommand())
                {
                    command.CommandText = query;
                    ParameterUtil.AddParameter(command, "idd", DbType.String);
                    command.Prepare();
                    ParameterUtil.SetParameterValue(command, "idd", idd);
                    using (IDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            skakac = new Skakac(reader.GetInt32(0), reader.GetString(1), reader.GetString(2),
                                reader.GetString(3), reader.GetInt32(4), reader.GetFloat(5));
                            result.Add(skakac);
                        }
                        
                    }
                }
            }

            return result;
        }

        public int Save(Skakac entity)
        {
            throw new NotImplementedException();
        }

        public int SaveAll(IEnumerable<Skakac> entities)
        {
            throw new NotImplementedException();
        }

        public int BrojTitula(string idd)
        {
            string query = "select sum(titule) " +
                        "from skakac where idd = :idd";
            using (IDbConnection connection = ConnectionUtil_Pooling.GetConnection())
            {
                connection.Open();
                using (IDbCommand command = connection.CreateCommand())
                {
                    command.CommandText = query;
                    ParameterUtil.AddParameter(command, "idd", DbType.String);                    
                    command.Prepare();
                    ParameterUtil.SetParameterValue(command, "idd", idd);                   

                    object result = command.ExecuteScalar();
                    if (result == null) return -1;
                    return Convert.ToInt32(result);
                }
            }
        }
    }
}
