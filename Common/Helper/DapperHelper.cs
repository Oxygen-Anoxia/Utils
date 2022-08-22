using Common.DB;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Common.Helper
{
    public class DapperHelper
    {
        private string connectionStr;
        public DapperHelper()
        {
            connectionStr = BaseDBConfig.ConnectionString;
            //connectionStr = Appsettings.app("ConnectionStrings", "Default");
        }

        public DapperHelper(bool iscustomer = false)
        {
            if (iscustomer)
            {
                connectionStr = Appsettings.app("ConnectionStrings", "Customer");
            }
        }

        public SqlConnection GetSqlConnection()
        {
            SqlConnection conn = new SqlConnection(connectionStr);
            conn.Open();
            return conn;
        }

        public List<T> Query<T>(string sql, List<T> model = null)
        {
            using (IDbConnection connection = GetSqlConnection())
            {
                return connection.Query<T>(sql, model).ToList();
            }
        }

        public List<T> QueryInid<T>(string sql, string[] c_ids)
        {
            var maxParametersSize = 2000;
            var c_idsReplace = c_ids.ToList().Distinct().ToArray();
            using (IDbConnection connection = GetSqlConnection())
            {
                if (c_ids.Length > maxParametersSize)
                {
                    List<T> res = new List<T>();

                    var roundNumber = c_ids.Length / maxParametersSize + 1;
                    for (int i = 0; i < roundNumber; i++)
                    {
                        c_ids = c_idsReplace.Skip(maxParametersSize * i).Take(maxParametersSize).ToArray();
                        res.AddRange(connection.Query<T>(sql, new { c_ids }));
                    }

                    return res;
                }
                else
                {
                    return connection.Query<T>(sql, new { c_ids }).ToList();
                }
            }
        }


        public T Select<T>(string sql)
        {
            using (IDbConnection connection = GetSqlConnection())
            {
                return connection.QueryFirstOrDefault<T>(sql);
            }
        }

        public int Exec(string sql)
        {
            using (IDbConnection connection = GetSqlConnection())
            {
                return connection.Execute(sql);
            }
        }

        public int Exec(string sql, object model)
        {
            using (IDbConnection connection = GetSqlConnection())
            {
                return connection.Execute(sql, model);
            }
        }

        public int Exec(string sql, object model, bool useTransaction = false)
        {
            using (IDbConnection connection = GetSqlConnection())
            {
                if (useTransaction)
                {
                    var tran = BeginTransaction(connection);
                    return connection.Execute(sql, model, tran);
                }
                else
                {
                    return connection.Execute(sql, model);
                }

            }
        }


        /// <summary>
        /// 必须是  in @c_ids
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="c_id"></param>
        /// <returns></returns>
        public List<T> QueryIn<T>(string sql, string[] c_ids)
        {
            using (IDbConnection connection = GetSqlConnection())
            {
                return connection.Query<T>(sql, new { c_ids }).ToList();
            }
        }

        /// <summary>
        /// 必须是 in @ids
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<T> QueryIn<T>(string sql, int[] ids)
        {
            using (IDbConnection connection = GetSqlConnection())
            {
                return connection.Query<T>(sql, new { ids }).ToList();
            }
        }

        private IDbTransaction BeginTransaction(IDbConnection conn)
        {
            IDbTransaction tran = conn.BeginTransaction();
            return tran;
        }

        public void InsertTable(DataTable dt, string tablename)
        {
            using (SqlBulkCopy bulkCopy = new SqlBulkCopy(connectionStr))
            {
                bulkCopy.DestinationTableName = tablename;
                bulkCopy.BatchSize = dt.Rows.Count;
                bulkCopy.WriteToServer(dt);
            }
        }
    }
}
