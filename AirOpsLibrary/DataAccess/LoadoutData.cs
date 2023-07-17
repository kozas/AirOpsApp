using AirOpsLibrary.DataAccess.Interfaces;
using AirOpsLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirOpsLibrary.DataAccess;

public class LoadoutData
{
    private readonly ISqlDataAccess sql;

    public LoadoutData(ISqlDataAccess sql)
    {
        this.sql = sql;
    }

    public Task<List<LoadoutModel>> GetAll()
    {
        return sql.LoadData<LoadoutModel, dynamic>("dbo.spLoadout_GetAll",
            new { },
            "Default");
    }
}
