Imports System.Data.OleDb

Public Class Form5
    Dim c_name As String
    Dim car As String

    Dim pro As String
    Dim connstring As String
    Dim command As String
    Dim myconnection As OleDbConnection = New OleDbConnection

    Private conn As New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=G:\garage management system\Database3.mdb")
    Dim dr As OleDbDataReader
    Private Sub Form5_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        conn.Open()
        ComboBox1.Items.Clear()
        Dim cmd As New OleDbCommand
        cmd.CommandText = "select * from Table1"
        cmd.Connection = conn
        dr = cmd.ExecuteReader
        While dr.Read
            ComboBox1.Items.Add(dr.GetString(2))
        End While
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        c_name = ComboBox1.Text
        car = ComboBox1.SelectedIndex
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        pro = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=G:\garage management system\Database3.mdb"
        connstring = pro
        myconnection.ConnectionString = connstring
        myconnection.Open()
        command = " delete from Table1 where [car_name]='" & c_name & "' "
        Dim cmd As OleDbCommand = New OleDbCommand(command, myconnection)
        ComboBox1.Items.RemoveAt(car)
        MsgBox("Car removed from Garage")
        Try
            cmd.ExecuteNonQuery()
            cmd.Dispose()
            myconnection.Close()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Hide()
        Form2.Show()
    End Sub
End Class