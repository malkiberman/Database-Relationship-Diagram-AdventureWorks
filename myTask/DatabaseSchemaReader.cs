using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace AdventureWorksVisualizer
{
    public class DatabaseSchemaReader
    {
        private readonly string _connectionString;

        public DatabaseSchemaReader(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<string> GetTables()
        {
            var tables = new List<string>();
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var query = "SELECT TABLE_SCHEMA + '.' + TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE = 'BASE TABLE'";
                using (var command = new SqlCommand(query, connection))
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        tables.Add(reader.GetString(0));
                    }
                }
            }
            return tables;
        }

        public List<EntityRelation> GetForeignKeys()
        {
            var relations = new List<EntityRelation>();
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var query = @"
                    SELECT 
                        fk.name AS FK_Name,
                        tp.name AS ParentTable,
                        tr.name AS ReferencedTable
                    FROM 
                        sys.foreign_keys fk
                    INNER JOIN 
                        sys.tables tp ON fk.parent_object_id = tp.object_id
                    INNER JOIN 
                        sys.tables tr ON fk.referenced_object_id = tr.object_id";
                using (var command = new SqlCommand(query, connection))
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        relations.Add(new EntityRelation
                        {
                            FromTable = reader.GetString(1),
                            ToTable = reader.GetString(2),
                            RelationName = reader.GetString(0)
                        });
                    }
                }
            }
            return relations;
        }
    }
}
