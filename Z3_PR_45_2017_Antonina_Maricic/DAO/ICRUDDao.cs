﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Z3_PR_45_2017_Antonina_Maricic.DAO
{
    public interface ICRUDDao<T, ID>
    {
        int Count();

        int Delete(T entity);

        int DeleteAll();

        int DeleteById(ID id);

        bool ExistsById(ID id);

        IEnumerable<T> FindAll();

        IEnumerable<T> FindAllById(IEnumerable<ID> ids);

        T FindById(ID id);

        int Save(T entity);

        int SaveAll(IEnumerable<T> entities);

    }
}
