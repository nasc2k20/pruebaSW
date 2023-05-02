Imports System.Data.SqlClient
Imports System.Reflection.Emit
Imports System.Windows.Forms.VisualStyles.VisualStyleElement

Public Class crudProductos

    Public Sub listarProducto(idProducto As Integer)
        Try
            Dim sqlQuery As New SqlCommand
            cnn.Open()
            sqlQuery.Connection = cnn
            sqlQuery.CommandText = "producto_listar"
            sqlQuery.CommandType = CommandType.StoredProcedure
            sqlQuery.Parameters.AddWithValue("idProducto", idProducto)
            Dim rd As SqlDataReader
            rd = sqlQuery.ExecuteReader

            If rd.Read Then
                TextBox1.Text = rd("codigoProducto")
                TextBox2.Text = rd("nombreProducto")
                TextBox3.Text = rd("precioProducto")
            End If

            cnn.Close()
        Catch ex As Exception
            MsgBox(ex.StackTrace)
        Finally
            cnn.Close()
        End Try
    End Sub
    Public Sub nuevoProducto(codigoProducto As Integer, nombreProducto As String, precioProducto As Double)
        Try
            Dim sqlQuery As New SqlCommand
            cnn.Open()
            sqlQuery.Connection = cnn
            sqlQuery.CommandText = "producto_insertar"
            sqlQuery.CommandType = CommandType.StoredProcedure
            sqlQuery.Parameters.AddWithValue("codigoProducto", Convert.ToInt32(codigoProducto))
            sqlQuery.Parameters.AddWithValue("nombreProducto", nombreProducto)
            sqlQuery.Parameters.AddWithValue("precioProducto", Double.Parse(precioProducto))

            sqlQuery.ExecuteNonQuery()
            cnn.Close()
        Catch ex As Exception
            MsgBox(ex.StackTrace)
        Finally
            cnn.Close()
        End Try

    End Sub

    Public Sub modificarProducto(idProducto As Integer, codigoProducto As Integer, nombreProducto As String, precioProducto As Double)
        Try
            Dim sqlQuery As New SqlCommand
            cnn.Open()
            sqlQuery.Connection = cnn
            sqlQuery.CommandText = "producto_actualizar"
            sqlQuery.CommandType = CommandType.StoredProcedure
            sqlQuery.Parameters.AddWithValue("idProducto", Convert.ToInt32(idProducto))
            sqlQuery.Parameters.AddWithValue("codigoProducto", Convert.ToInt32(codigoProducto))
            sqlQuery.Parameters.AddWithValue("nombreProducto", nombreProducto)
            sqlQuery.Parameters.AddWithValue("precioProducto", Double.Parse(precioProducto))

            sqlQuery.ExecuteNonQuery()
            cnn.Close()
        Catch ex As Exception
            MsgBox(ex.StackTrace)
        Finally
            cnn.Close()
        End Try


    End Sub

    Private Sub crudProductos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Label4.Visible = False
        Label5.Visible = False

        If Label4.Text = "modificar" Then
            Me.Text = "Modificar Producto"
            listarProducto(Convert.ToInt32(Label5.Text))
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If Label4.Text = "modificar" Then
            modificarProducto(Convert.ToInt32(Label5.Text), Convert.ToInt32(TextBox1.Text), TextBox2.Text, Convert.ToDouble(TextBox3.Text))
        Else
            nuevoProducto(Convert.ToInt32(TextBox1.Text), TextBox2.Text, Convert.ToDouble(TextBox3.Text))
        End If

        Close()
        verProductos.verProductos()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Close()
    End Sub
End Class