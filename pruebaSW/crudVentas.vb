Imports System.Data.SqlClient

Public Class crudVentas

    Public Sub llenarComboEmpleados()
        Try
            Dim sqlQuery As String

            sqlQuery = "listarEmpleadoCombo"
            Dim daQuery As New SqlDataAdapter(sqlQuery, cnn)
            Dim dtQuery As New DataTable

            cnn.Open()
            daQuery.Fill(dtQuery)
            With ComboBox1
                .DataSource = dtQuery
                .DisplayMember = "NombreCompleto"
                .ValueMember = "idEmpleado"
            End With
            cnn.Close()
        Catch ex As Exception
            MsgBox(ex.StackTrace)
        Finally
            cnn.Close()
        End Try
    End Sub

    Public Sub listarProductoVenta(idProducto As Integer)
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
                TextBox2.Text = rd("nombreProducto")
                TextBox4.Text = rd("precioProducto")
                'TextBox5.Text = Convert.ToDouble(Val(TextBox4.Text) * Val(TextBox3.Text))
            End If

            cnn.Close()
        Catch ex As Exception
            MsgBox(ex.StackTrace)
        Finally
            cnn.Close()
        End Try
    End Sub

    Public Sub nuevaVenta(idEmpleado As Integer, idProducto As Integer,
                          cantidadVenta As Integer, precioVenta As Double, totalVenta As Double)
        Try
            Dim sqlQuery As New SqlCommand
            cnn.Open()
            sqlQuery.Connection = cnn
            sqlQuery.CommandText = "venta_insertar"
            sqlQuery.CommandType = CommandType.StoredProcedure
            sqlQuery.Parameters.AddWithValue("idEmpleado", Convert.ToInt32(idEmpleado))
            sqlQuery.Parameters.AddWithValue("idProducto", Convert.ToInt32(idProducto))
            sqlQuery.Parameters.AddWithValue("cantidadVenta", Convert.ToInt32(cantidadVenta))
            sqlQuery.Parameters.AddWithValue("precioVenta", Double.Parse(precioVenta))
            sqlQuery.Parameters.AddWithValue("totalVenta", Double.Parse(totalVenta))

            sqlQuery.ExecuteNonQuery()
            cnn.Close()
        Catch ex As Exception
            MsgBox(ex.StackTrace)
        Finally
            cnn.Close()
        End Try

    End Sub

    Private Sub crudVentas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        llenarComboEmpleados()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        nuevaVenta(Convert.ToInt32(ComboBox1.SelectedValue), Convert.ToInt32(TextBox1.Text),
                   Convert.ToInt32(TextBox3.Text), Convert.ToDouble(TextBox4.Text), Convert.ToDouble(TextBox5.Text))
        Close()
        verVentas.verVentas()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Close()
    End Sub

    Private Sub TextBox1_KeyUp(sender As Object, e As KeyEventArgs) Handles TextBox1.KeyUp
        If e.KeyCode = 13 Then
            listarProductoVenta(Convert.ToInt32(TextBox1.Text))
            TextBox3.Focus()
        End If
    End Sub

    Private Sub TextBox3_KeyUp(sender As Object, e As KeyEventArgs) Handles TextBox3.KeyUp
        If e.KeyCode = 13 Then
            TextBox5.Text = Convert.ToDouble(Val(TextBox4.Text) * Val(TextBox3.Text))
            Button1.Focus()
        End If
    End Sub
End Class