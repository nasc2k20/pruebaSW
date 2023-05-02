Imports System.Data.SqlClient
Public Class nuevoEmpleado

    Public Sub listarEmpleado(idEmpleado As Integer)
        Try
            Dim sqlQuery As New SqlCommand
            cnn.Open()
            sqlQuery.Connection = cnn
            sqlQuery.CommandText = "empleado_listar"
            sqlQuery.CommandType = CommandType.StoredProcedure
            sqlQuery.Parameters.AddWithValue("idEmpleado", idEmpleado)
            Dim rd As SqlDataReader
            rd = sqlQuery.ExecuteReader

            If rd.Read Then
                TextBox1.Text = rd("codigoEmpleado")
                TextBox2.Text = rd("nombresEmpleado")
                TextBox3.Text = rd("apellidosEmpleado")
                TextBox4.Text = rd("correoEmpleado")
                TextBox5.Text = rd("salarioEmpleado")
            End If

            cnn.Close()
        Catch ex As Exception
            MsgBox(ex.StackTrace)
        Finally
            cnn.Close()
        End Try
    End Sub
    Public Sub nuevoEmpleado(codigoEmpleado As String, nombresEmpleado As String, apellidosEmpleado As String,
                             correoEmpleado As String, salarioEmpleado As Double)
        Try
            Dim sqlQuery As New SqlCommand
            cnn.Open()
            sqlQuery.Connection = cnn
            sqlQuery.CommandText = "empleado_insertar"
            sqlQuery.CommandType = CommandType.StoredProcedure
            sqlQuery.Parameters.AddWithValue("codigoEmpleado", codigoEmpleado)
            sqlQuery.Parameters.AddWithValue("nombresEmpleado", nombresEmpleado)
            sqlQuery.Parameters.AddWithValue("apellidosEmpleado", apellidosEmpleado)
            sqlQuery.Parameters.AddWithValue("correoEmpleado", correoEmpleado)
            sqlQuery.Parameters.AddWithValue("salarioEmpleado", Double.Parse(salarioEmpleado))

            sqlQuery.ExecuteNonQuery()
            cnn.Close()
        Catch ex As Exception
            MsgBox(ex.StackTrace)
        Finally
            cnn.Close()
        End Try

    End Sub

    Public Sub modificarEmpleado(idEmpleado As Integer, codigoEmpleado As String, nombresEmpleado As String,
                                 apellidosEmpleado As String, correoEmpleado As String, salarioEmpleado As Double)
        Try
            Dim sqlQuery As New SqlCommand
            cnn.Open()
            sqlQuery.Connection = cnn
            sqlQuery.CommandText = "empleado_actualizar"
            sqlQuery.CommandType = CommandType.StoredProcedure
            sqlQuery.Parameters.AddWithValue("idEmpleado", idEmpleado)
            sqlQuery.Parameters.AddWithValue("codigoEmpleado", codigoEmpleado)
            sqlQuery.Parameters.AddWithValue("nombresEmpleado", nombresEmpleado)
            sqlQuery.Parameters.AddWithValue("apellidosEmpleado", apellidosEmpleado)
            sqlQuery.Parameters.AddWithValue("correoEmpleado", correoEmpleado)
            sqlQuery.Parameters.AddWithValue("salarioEmpleado", Double.Parse(salarioEmpleado))

            sqlQuery.ExecuteNonQuery()
            cnn.Close()
        Catch ex As Exception
            MsgBox(ex.StackTrace)
        Finally
            cnn.Close()
        End Try


    End Sub
    Private Sub nuevoEmpleado_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Label6.Visible = False
        Label7.Visible = False

        If Label6.Text = "modificar" Then
            Me.Text = "Modificar Empleado"
            listarEmpleado(Convert.ToInt32(Label7.Text))
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        If Label6.Text = "modificar" Then
            modificarEmpleado(Convert.ToInt32(Label7.Text), TextBox1.Text, TextBox2.Text,
                              TextBox3.Text, TextBox4.Text, Convert.ToDouble(TextBox5.Text))
        Else
            nuevoEmpleado(TextBox1.Text, TextBox2.Text, TextBox3.Text, TextBox4.Text, Convert.ToDouble(TextBox5.Text))
        End If

        Close()
        verEmpleados.verEmpleados()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Close()
    End Sub
End Class