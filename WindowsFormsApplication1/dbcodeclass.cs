﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;


namespace WindowsFormsApplication1
{
    class dbcodeclass
    {
         public SqlConnection cn;
        public dbcodeclass()
        {
            cn = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=F:\BACKUP\PROJECT\GMS\WindowsFormsApplication1\WindowsFormsApplication1\Database1.mdf;Integrated Security=True;User Instance=True");
            cn.Open();
        }
        public int GetAutoID(string sql)
        {
            int i = 1;
            try
            {
                DataTable dt = GettableData(sql);
                if (dt.Rows.Count >= 1)
                {
                    i = (int.Parse(dt.Rows[0][0].ToString()) + 1);
                }
                else
                    i = 1;
            }
            catch
            {
                i = 1;
            }
            return i;
        }
        public DataTable GettableData(string sql)
        {
            SqlDataAdapter da = new SqlDataAdapter(sql, cn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public void FillGridData(DataGridView dv, string sql)
        {
            DataTable dt = GettableData(sql);
            dv.DataSource = dt;
        }
        public void ExecuteSqlQuery(string sql)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandText = sql;
            cmd.ExecuteNonQuery();
        }
        public void FillCombo(ComboBox cb, string sql, String dismemb, string val)
        {
            DataTable dt = GettableData(sql);
            cb.ValueMember = val;
            cb.DisplayMember = dismemb;
            cb.DataSource = dt;
        }
        internal void FillCombo(string p)
        {
            throw new NotImplementedException();
        }   

        
    }
}

   