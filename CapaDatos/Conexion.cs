﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class Conexion
    {
        #region Singleton
        private static readonly Conexion unicaInstancia = new Conexion();

        public static Conexion Instancia
        {
            get
            {

                return Conexion.unicaInstancia;
            }

        }

        #endregion Singleton                                            

        public SqlConnection Conectar()
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = "Data Source=LAPTOP-NKF3D1PK\\SQLEXPRESS02;" +
                                  "Initial Catalog=DiarsAlfa;" +
                                  "Integrated Security=True;";
            return cn;
        }
    }
}
