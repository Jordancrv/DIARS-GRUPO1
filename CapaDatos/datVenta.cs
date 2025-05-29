using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using CapaEntidad;
using Microsoft.Win32;
using static System.Net.Mime.MediaTypeNames;
using static CapaEntidad.Class1;

namespace CapaDatos
{
    public class datVenta
    {
        #region Singleton
        private static readonly datVenta UnicaInstancia = new datVenta();
        public static datVenta Instancia
        {
            get { return datVenta.UnicaInstancia; }
        }
        #endregion Singleton

        #region Métodos

        public bool RegistrarVenta(entVenta venta, out int ventaId, out string mensaje)
        {
            SqlCommand cmd = null;
            ventaId = 0;
            mensaje = string.Empty;
            bool resultado = false;

            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("sp_RegistrarVenta", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                
                cmd.Parameters.AddWithValue("@ClienteId", venta.Cliente.ClienteId);
                cmd.Parameters.AddWithValue("@UsuarioId", venta.Vendedor.UsuarioId);
                cmd.Parameters.AddWithValue("@AlmacenId", venta.AlmacenId);

                
                DataTable dtDetalles = new DataTable();
                dtDetalles.Columns.Add("PresentacionId", typeof(int));
                dtDetalles.Columns.Add("Cantidad", typeof(int));
                dtDetalles.Columns.Add("PrecioUnitario", typeof(decimal));
                dtDetalles.Columns.Add("Descuento", typeof(decimal));
                dtDetalles.Columns.Add("PromocionId", typeof(int));

                foreach (var detalle in venta.Detalles)
                {
                    dtDetalles.Rows.Add(
                        detalle.Presentacion.PresentacionId,
                        detalle.Cantidad,
                        detalle.PrecioUnitario,
                        detalle.Descuento,
                        detalle.Promocion?.PromocionId ?? 0
                    );
                }

                SqlParameter paramDetalles = cmd.Parameters.AddWithValue("@DetallesVenta", dtDetalles);
                paramDetalles.SqlDbType = SqlDbType.Structured;
                paramDetalles.TypeName = "DetalleVentaType";

                SqlParameter paramResultado = new SqlParameter("@Resultado", SqlDbType.Bit);
                paramResultado.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(paramResultado);

                SqlParameter paramMensaje = new SqlParameter("@Mensaje", SqlDbType.VarChar, 500);
                paramMensaje.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(paramMensaje);

                SqlParameter paramVentaId = new SqlParameter("@VentaId", SqlDbType.Int);
                paramVentaId.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(paramVentaId);

                cn.Open();
                cmd.ExecuteNonQuery();

                resultado = Convert.ToBoolean(paramResultado.Value);
                mensaje = paramMensaje.Value.ToString();
                ventaId = Convert.ToInt32(paramVentaId.Value);
            }
            catch (SqlException e)
            {
                mensaje = "Error al registrar venta: " + e.Message;
                resultado = false;
            }
            finally
            {
                if (cmd != null && cmd.Connection.State == ConnectionState.Open)
                    cmd.Connection.Close();
            }

            return resultado;
        }

        public List<entVenta> ListarVentasPorFecha(DateTime fechaInicio, DateTime fechaFin)
        {
            SqlCommand cmd = null;
            List<entVenta> lista = new List<entVenta>();

            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("sp_ListarVentasPorFecha", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@FechaInicio", fechaInicio);
                cmd.Parameters.AddWithValue("@FechaFin", fechaFin);

                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    entVenta venta = new entVenta
                    {
                        VentaId = Convert.ToInt32(dr["VentaId"]),
                        NumeroVenta = dr["NumeroVenta"].ToString(),
                        Fecha = Convert.ToDateTime(dr["Fecha"]),
                        Estado = Convert.ToBoolean(dr["Estado"]),
                        Cliente = new entCliente
                        {
                            ClienteId = Convert.ToInt32(dr["ClienteId"]),
                            RazonSocial = dr["RazonSocial"].ToString()
                        }
                       
                    };

                    lista.Add(venta);
                }
            }
            catch (SqlException e)
            {
                throw new Exception("Error al listar ventas: " + e.Message);
            }
            finally
            {
                if (cmd != null && cmd.Connection.State == ConnectionState.Open)
                    cmd.Connection.Close();
            }

            return lista;
        }


        public entVenta ObtenerVentaPorId(int ventaId)
        {
            SqlCommand cmd = null;
            entVenta venta = null;

            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("sp_ObtenerVentaPorId", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@VentaId", ventaId);

                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    venta = new entVenta
                    {
                        VentaId = Convert.ToInt32(dr["VentaId"]),
                        NumeroVenta = dr["NumeroVenta"].ToString(),
                        Fecha = Convert.ToDateTime(dr["Fecha"]),
                        Estado = Convert.ToBoolean(dr["Estado"]),
                        Cliente = new entCliente
                        {
                            ClienteId = Convert.ToInt32(dr["ClienteId"]),
                            NumeroDocumento = dr["NumeroDocumento"].ToString(),
                            RazonSocial = dr["RazonSocial"].ToString()
                        }
                    };
                }

                if (venta != null)
                {
                    dr.NextResult();
                    venta.Detalles = new List<entVentaDetalle>();

                    while (dr.Read())
                    {
                        venta.Detalles.Add(new entVentaDetalle
                        {
                            Presentacion = new entPresentacion
                            {
                                PresentacionId = Convert.ToInt32(dr["PresentacionId"]),
                                Nombre = dr["Presentacion"].ToString(),
                                Precio = Convert.ToDecimal(dr["PrecioUnitario"])
                            },
                            Cantidad = Convert.ToInt32(dr["Cantidad"]),
                            Descuento = Convert.ToDecimal(dr["Descuento"]),
                            Subtotal = Convert.ToDecimal(dr["Subtotal"])
                        });
                    }
                }
            }
            catch (SqlException e)
            {
                throw new Exception("Error al obtener venta: " + e.Message);
            }
            finally
            {
                if (cmd != null && cmd.Connection.State == ConnectionState.Open)
                    cmd.Connection.Close();
            }

            return venta;
        }


        public bool AnularVenta(int ventaId, out string mensaje)
        {
            SqlCommand cmd = null;
            bool resultado = false;
            mensaje = string.Empty;

            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("sp_AnularVenta", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@VentaId", ventaId);
                SqlParameter paramResultado = new SqlParameter("@Resultado", SqlDbType.Bit)
                {
                    Direction = ParameterDirection.Output
                };
                cmd.Parameters.Add(paramResultado);

                SqlParameter paramMensaje = new SqlParameter("@Mensaje", SqlDbType.VarChar, 500)
                {
                    Direction = ParameterDirection.Output
                };
                cmd.Parameters.Add(paramMensaje);

                cn.Open();
                cmd.ExecuteNonQuery();

                resultado = Convert.ToBoolean(paramResultado.Value);
                mensaje = paramMensaje.Value.ToString();
            }
            catch (SqlException e)
            {
                mensaje = "Error al anular venta: " + e.Message;
                resultado = false;
            }
            finally
            {
                if (cmd != null && cmd.Connection.State == ConnectionState.Open)
                    cmd.Connection.Close();
            }

            return resultado;
        }


        #endregion Métodos
       /* CREATE PROCEDURE sp_RegistrarVenta
    @ClienteId INT,
    @UsuarioId INT,
    @AlmacenId INT,
    @DetallesVenta DetalleVentaType READONLY,
    @Resultado BIT OUTPUT,
    @Mensaje VARCHAR(500) OUTPUT,
    @VentaId INT OUTPUT
        AS
BEGIN
    BEGIN TRY
        BEGIN TRANSACTION;
        
        -- 1. Registrar Pedido
        DECLARE @PedidoId INT;
        DECLARE @NumeroPedido VARCHAR(10) = 'P' + RIGHT('000000' + CAST(NEXT VALUE FOR seq_pedidos AS VARCHAR(6)), 6);
        
        INSERT INTO Pedido(NumeroPedido, ClienteId, Fecha, EstadoId, AlmacenId)
        VALUES(@NumeroPedido, @ClienteId, GETDATE(), 1, @AlmacenId);

        SET @PedidoId = SCOPE_IDENTITY();
        
        -- 2. Registrar Detalles del Pedido
        INSERT INTO PedidoDetalle(PedidoId, PresentacionId, Cantidad, PromocionId)
        SELECT @PedidoId, PresentacionId, Cantidad, PromocionId
        FROM @DetallesVenta;
        
        -- 3. Registrar Venta
        DECLARE @NumeroVenta CHAR(7) = 'V' + RIGHT('000000' + CAST(NEXT VALUE FOR seq_ventas AS VARCHAR(6)), 6);
        
        INSERT INTO Venta(NumeroVenta, PedidoId, Fecha, Estado)
        VALUES(@NumeroVenta, @PedidoId, GETDATE(), 1);

        SET @VentaId = SCOPE_IDENTITY();
        
        -- 4. Actualizar Stock
        UPDATE APD
        SET APD.Stock = APD.Stock - DV.Cantidad
        FROM AlmacenPresentacionDetalle APD
        INNER JOIN @DetallesVenta DV ON APD.PresentacionId = DV.PresentacionId
        WHERE APD.AlmacenId = @AlmacenId;
        
        -- 5. Registrar Movimiento de Inventario
        INSERT INTO OrdenSalida(NumeroOrdenSalida, VentaId, FechaSalida, Estado)
        VALUES('OS' + RIGHT('000000' + CAST(NEXT VALUE FOR seq_ordenes_salida AS VARCHAR(6)), 6), @VentaId, GETDATE(), 1);
        
        DECLARE @OrdenSalidaId INT = SCOPE_IDENTITY();

        INSERT INTO OrdenSalidaDetalle(OrdenSalidaId, PresentacionId, Cantidad, Estado)
        SELECT @OrdenSalidaId, PresentacionId, Cantidad, 1
        FROM @DetallesVenta;

        COMMIT TRANSACTION;
        SET @Resultado = 1;
        SET @Mensaje = 'Venta registrada correctamente';
        END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        SET @Resultado = 0;
        SET @Mensaje = ERROR_MESSAGE();
        SET @VentaId = 0;
        END CATCH
END;
select* from Cliente

CREATE TYPE DetalleVentaType AS TABLE
(
    PresentacionId INT,
    Cantidad INT,
    PrecioUnitario DECIMAL(10,2),
    Descuento DECIMAL(10,2),
    PromocionId INT
);


        CREATE PROCEDURE sp_ListarVentasPorFecha
            @FechaInicio DATE,
    @FechaFin DATE
AS
BEGIN
    SELECT
        v.VentaId,
        v.NumeroVenta,
        v.Fecha,
        v.Estado,
        c.ClienteId,
        c.RazonSocial
    FROM Venta v
    INNER JOIN Pedido p ON v.PedidoId = p.PedidoId
    INNER JOIN Cliente c ON p.ClienteId = c.ClienteId
    WHERE v.Fecha BETWEEN @FechaInicio AND @FechaFin;
        END;

CREATE PROCEDURE sp_ObtenerVentaPorId
    @VentaId INT
AS
BEGIN
    SET NOCOUNT ON;

    -- Primer conjunto de resultados: Información general de la venta(sin vendedor)
    SELECT
        V.VentaId,
        V.NumeroVenta,
        V.Fecha,
        V.Estado,
        C.ClienteId,
        C.NumeroDocumento,
        C.RazonSocial
        -- Usuario eliminado porque no existe en el modelo actual
    FROM Venta V
    INNER JOIN Pedido P ON V.PedidoId = P.PedidoId
    INNER JOIN Cliente C ON P.ClienteId = C.ClienteId
    WHERE V.VentaId = @VentaId;

    -- Segundo conjunto de resultados: Detalles de la venta
    SELECT
        VD.PresentacionId,
        PR.Nombre AS Presentacion,
        PR.Precio AS PrecioUnitario,
        VD.Cantidad,
        VD.Descuento,
        (VD.Cantidad* PR.Precio) - VD.Descuento AS Subtotal
    FROM VentaDetalle VD
    INNER JOIN Presentacion PR ON VD.PresentacionId = PR.PresentacionId
    WHERE VD.VentaId = @VentaId;
        END;


CREATE PROCEDURE sp_AnularVenta
    @VentaId INT,
    @Resultado BIT OUTPUT,
    @Mensaje VARCHAR(500) OUTPUT
AS
BEGIN
    SET NOCOUNT ON;

        BEGIN TRY
        -- Verificar si la venta existe y está activa
        IF EXISTS(SELECT 1 FROM Venta WHERE VentaId = @VentaId AND Estado = 1)
        BEGIN
            -- Actualizar el estado a 0 (anulado/inactivo)
            UPDATE Venta
            SET Estado = 0
            WHERE VentaId = @VentaId;

        SET @Resultado = 1;
        SET @Mensaje = 'Venta anulada correctamente.';
        END
        ELSE
        BEGIN
            SET @Resultado = 0;
            SET @Mensaje = 'La venta no existe o ya está anulada.';
        END
    END TRY
    BEGIN CATCH
        SET @Resultado = 0;
        SET @Mensaje = ERROR_MESSAGE();
        END CATCH
END;*/

        //Esos son los procedimientos almacenados//
    }
}