Imports System.Data.SqlClient
Public Class conexion
    Public conexion As SqlConnection = New SqlConnection("Data Source=DESKTOP-O55QRS2\MSSQLSERVERSAM;Initial Catalog=Tienda;Integrated Security=True")
    Public ds As DataSet = New DataSet()
    Public da As SqlDataAdapter
    Public cmb As SqlCommand
    Public dr As SqlDataReader

    Public Sub abrirConexion()
        Try
            conexion.Open()
        Catch ex As Exception
            MessageBox.Show("No se pudo Conectar: " + ex.ToString)
            End
        Finally
            conexion.Close()
        End Try
    End Sub

    Public Function insertarUsuario(idUsuario As Integer, nombre As String, apellido As String, userName As String,
                                    psw As String, rol As String, estado As String, correo As String)
        Try
            conexion.Open()

            cmb = New SqlCommand("insertarUsuario", conexion)
            cmb.CommandType = CommandType.StoredProcedure

            cmb.Parameters.AddWithValue("@idUsuario", idUsuario)
            cmb.Parameters.AddWithValue("@nombre", nombre)
            cmb.Parameters.AddWithValue("@apellido", apellido)
            cmb.Parameters.AddWithValue("@userName", userName)
            cmb.Parameters.AddWithValue("@psw", psw)
            cmb.Parameters.AddWithValue("@rol", rol)
            cmb.Parameters.AddWithValue("@estado", estado)
            cmb.Parameters.AddWithValue("@correo", correo)

            If cmb.ExecuteNonQuery <> 0 Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        Finally
            conexion.Close()
        End Try
    End Function

    Public Function eliminarUsuario(idUsuario As Integer, rol As String)

        Try
            conexion.Open()
            cmb = New SqlCommand("eliminarUsuario", conexion)
            cmb.CommandType = CommandType.StoredProcedure
            cmb.Parameters.AddWithValue("@idUsuario", idUsuario)
            cmb.Parameters.AddWithValue("@rol", rol)

            If cmb.ExecuteNonQuery <> 0 Then
                Return True
            Else
                Return False
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        Finally
            conexion.Close()

        End Try

    End Function

    Public Function BuscarUsuario(userName As String)

        Try
            conexion.Open()
            cmb = New SqlCommand("busquedaUsuario", conexion)
            cmb.CommandType = CommandType.StoredProcedure
            cmb.Parameters.AddWithValue("@userName", userName)

            If cmb.ExecuteNonQuery Then
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmb)
                da.Fill(dt)
                Return dt
                conexion.Close()
            Else
                Return Nothing
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        Finally
            conexion.Close()
        End Try
    End Function

    Public Function actualizarUsuario(idUsuario As Integer, nombre As String, apellido As String,
                                      userName As String, psw As String, correo As String, rol As String, estado As String)
        Try
            conexion.Open()
            cmb = New SqlCommand("modificarUsuario", conexion)
            cmb.CommandType = CommandType.StoredProcedure
            cmb.Parameters.AddWithValue("@idUsuario", idUsuario)
            cmb.Parameters.AddWithValue("@nombre", nombre)
            cmb.Parameters.AddWithValue("@apellido", apellido)
            cmb.Parameters.AddWithValue("@nombreUsuario", userName)
            cmb.Parameters.AddWithValue("@psw", psw)
            cmb.Parameters.AddWithValue("@correo", correo)
            cmb.Parameters.AddWithValue("@rol", rol)
            cmb.Parameters.AddWithValue("@estado", estado)

            If cmb.ExecuteNonQuery Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        Finally
            conexion.Close()
        End Try
    End Function

End Class
