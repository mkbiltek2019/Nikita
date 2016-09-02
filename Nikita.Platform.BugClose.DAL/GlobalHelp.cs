﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nikita.Base.ConnectionManager;
using Nikita.Base.Define;
using Nikita.DataAccess4DBHelper; 

namespace Nikita.Platform.BugClose
{
    public class GlobalHelp
    {
        public static string Conn = ConfigConnection.BugCloseConnection;
        public static SqlType SqlType = SqlType.SqlServer; 
        private static readonly object SyncObject = new object();
        private static IDbHelper _dbHelper;
 
        public static IDbHelper GetDataAccessHelper()
        {
            if (_dbHelper == null)
            {
                lock (SyncObject)
                {
                    if (_dbHelper == null)
                    {
                        _dbHelper = DbHelper.GetDbHelper(SqlType, Conn);
                    }
                }
            }
            return _dbHelper;
        } 
    }
}
