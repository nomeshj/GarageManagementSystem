Imports System.Data.OleDb
Public Class Form3
    Dim pro As String
    Dim connstring As String
    Dim command As String
    Dim myconnection As OleDbConnection = New OleDbConnection

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If TextBox1.Text = "" Then
            MsgBox("Enter Customer name")
        ElseIf TextBox2.Text = "" Then
            MsgBox("Enter Car name")
        ElseIf TextBox3.Text = "" Then
            MsgBox("Enter Car number")
        ElseIf TextBox4.Text = "" Then
            MsgBox("Enter Mobile no")
        Else

            pro = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=G:\garage management system\Database3.mdb"
            connstring = pro
            myconnection.ConnectionString = connstring
            myconnection.Open()
            'command = "insert into Table1([car_name]) values ('" & TextBox2.Text & "')"
            command = "insert into Table1([cust_name],[car_name],[car_no],[mobile_no]) values ('" & TextBox1.Text & "','" & TextBox2.Text & "','" & TextBox3.Text & "','" & TextBox4.Text & "')"
            Dim cmd As OleDbCommand = New OleDbCommand(command, myconnection)
            cmd.Parameters.Add(New OleDbParameter("cust_name", CType(TextBox1.Text, String)))
            cmd.Parameters.Add(New OleDbParameter("car_name", CType(TextBox2.Text, String)))
            cmd.Parameters.Add(New OleDbParameter("car_no", CType(TextBox3.Text, String)))
            cmd.Parameters.Add(New OleDbParameter("mobile_no", CType(TextBox4.Text, String)))


            MsgBox("record saved!")
            Try
                cmd.ExecuteNonQuery()
                cmd.Dispose()
                myconnection.Close()
                TextBox2.Clear()
                TextBox1.Clear()
                TextBox4.Clear()
                TextBox3.Clear()

            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Hide()
        Form2.Show()

    End Sub
End Class