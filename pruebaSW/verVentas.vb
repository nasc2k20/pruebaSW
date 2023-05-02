Imports System.Data.SqlClient

Public Class verVentas

    Public Sub verVentas()
        Try
            Dim sqlQuery As String

            sqlQuery = "venta_consultar"
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
    Public Sub eliminarVenta(idVenta As Integer)
        Try
            Dim sqlQuery As New SqlCommand
            cnn.Open()
            sqlQuery.Connection = cnn
            sqlQuery.CommandText = "venta_eliminar"
            sqlQuery.CommandType = CommandType.StoredProcedure
            sqlQuery.Parameters.AddWithValue("idVenta", Convert.ToInt32(idVenta))

            sqlQuery.ExecuteNonQuery()
            cnn.Close()
        Catch ex As Exception
            MsgBox(ex.StackTrace)
        Finally
            cnn.Close()
        End Try

    End Sub
    Private Sub verVentas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        verVentas()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'crudProductos.Label4.Text = "agregar"
        crudVentas.ShowDialog()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        crudProductos.Label4.Text = "modificar"
        crudProductos.Label5.Text = DataGridView1.CurrentRow.Cells(0).Value
        crudProductos.ShowDialog()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If MsgBox("¿Desea Eliminar el Registro?", MsgBoxStyle.YesNo, "Confirmacion") = MsgBoxResult.Yes Then
            eliminarVenta(Convert.ToInt32(DataGridView1.CurrentRow.Cells(0).Value))

            verVentas()
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Close()
    End Sub
End Class