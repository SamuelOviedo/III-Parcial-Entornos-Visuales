Imports System.Data.SqlClient
Public Class conexion
    Public conexion As SqlConnection = New SqlConnection("Data Source=DESKTOP-O55QRS2\MSSQLSERVERSAM;Initial Catalog=Tienda;Integrated Security=True")
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
End Class
