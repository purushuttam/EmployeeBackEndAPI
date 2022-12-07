using Npgsql;
using System.Data;
using System.Reflection;

namespace EmployeeBackendAPI.Model.Comman
{
    public class Npg
    {
        public static List<dynamic> GetListFromDT(Type className, DataTable dataTable)
        {
            List<dynamic> list = new List<dynamic>();
            foreach (DataRow row in dataTable.Rows)
            {
                object objClass = Activator.CreateInstance(className);
                Type type = objClass.GetType();
                foreach (DataColumn column in row.Table.Columns)
                {
                    PropertyInfo prop = type.GetProperty(column.ColumnName);
                    prop.SetValue(objClass, row.IsNull(column.ColumnName) ? null : row[column.ColumnName], null);
                }
                list.Add(objClass);
            }
            return list;
        }

        public static IEnumerable<T> MapToValue<T>(NpgsqlDataReader reader)
        {
            var data = new DataTable();
            data.Load(reader);
            List<dynamic> dynamicListReturned = GetListFromDT(typeof(T), data);
            IEnumerable<T> result = dynamicListReturned.Cast<T>().ToList();
            return result;
        }
    }
}
