Imports System.Data.SqlClient
Public Class verEmpleados


    Public Sub verEmpleados()
        Try
            Dim sqlQuery As String

            sqlQuery = "dbo.empleado_consultar"
            Dim daQuery As New SqlDataAdapter(sqlQuery, cnn)
            Dim dtQuery As New DataTable

            cnn.Open()
            daQuery.Fill(dtQuery)
            With DataGridView1
                .DataSource = dtQuery
            End With
            cnn.Close()
        Catch ex As Exception
            MsgBox(ex.StackTrace)
        Finally
            cnn.Close()
        End Try
    End Sub

    Public Sub eliminarEmpleado(idEmpleado As Integer)
        Try
            Dim sqlQuery As New SqlCommand
            cnn.Open()
            sqlQuery.Connection = cnn
            sqlQuery.CommandText = "empleado_eliminar"
            sqlQuery.CommandType = CommandType.StoredProcedure
            sqlQuery.Parameters.AddWithValue("idEmpleado", Convert.ToInt32(idEmpleado))

            sqlQuery.ExecuteNonQuery()
            cnn.Close()
        Catch ex As Exception
            MsgBox(ex.StackTrace)
        Finally
            cnn.Close()
        End Try

    End Sub
    Private Sub verEmpleados_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        verEmpleados()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        nuevoEmpleado.Label6.Text = "agregar"
        nuevoEmpleado.ShowDialog()

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        nuevoEmpleado.Label6.Text = "modificar"
        nuevoEmpleado.Label7.Text = DataGridView1.CurrentRow.Cells(0).Value
        nuevoEmpleado.ShowDialog()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If MsgBox("¿Desea Eliminar el Registro?", MsgBoxStyle.YesNo, "Confirmacion") = MsgBoxResult.Yes Then
            eliminarEmpleado(Convert.ToInt32(DataGridView1.CurrentRow.Cells(0).Value))

            verEmpleados()
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Close()
    End Sub
End Class