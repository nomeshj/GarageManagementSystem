Imports System.Data.OleDb

Public Class Form4
    Dim price1 As Integer
    Dim c_name As String

    Dim pro As String
    Dim connstring As String
    Dim command As String
    Dim myconnection As OleDbConnection = New OleDbConnection

    Private conn As New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=G:\garage management system\Database3.mdb")
    Dim dr As OleDbDataReader

    Private Sub Form4_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        conn.Open()
        ComboBox1.Items.Clear()
        Dim cmd As New OleDbCommand
        cmd.CommandText = "select * from Table1"
        cmd.Connection = conn
        dr = cmd.ExecuteReader
        While dr.Read
            ComboBox1.Items.Add(dr.GetString(1))
        End While

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        price1 = 0
        If ComboBox1.SelectedItem = "" Then
            MsgBox("could not modify car")

        Else

            If CheckBox1.Checked = True Then
                price1 = price1 + 200
            End If
            If CheckBox2.Checked = True Then
                price1 = price1 + 500
            End If
            If CheckBox3.Checked = True Then
                price1 = price1 + 300
            End If
            If CheckBox4.Checked = True Then
                price1 = price1 + 160
            End If
            If CheckBox5.Checked = True Then
                price1 = price1 + 250
            End If
            If CheckBox6.Checked = True Then
                price1 = price1 + 220
            End If
            If CheckBox7.Checked = True Then
                price1 = price1 + 150
            End If
            If CheckBox8.Checked = True Then
                price1 = price1 + 400
            End If
            If CheckBox9.Checked = True Then
                price1 = price1 + 500
            End If
            If CheckBox10.Checked = True Then
                price1 = price1 + 250
            End If
            If CheckBox11.Checked = True Then
                price1 = price1 + 460
            End If
            If CheckBox12.Checked = True Then
                price1 = price1 + 300
            End If
            If CheckBox13.Checked = True Then
                price1 = price1 + 310
            End If
            If CheckBox14.Checked = True Then
                price1 = price1 + 280
            End If
            MsgBox("Total Amount=" & price1)
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If price1 = 0 Then
            MsgBox("please make Total first!")
        Else

            pro = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=G:\garage management system\Database3.mdb"
            connstring = pro
            myconnection.ConnectionString = connstring
            myconnection.Open()
            command = " update Table1 set [price]='" & price1 & "' where [cust_name]='" & c_name & "' "
            Dim cmd As OleDbCommand = New OleDbCommand(command, myconnection)
            MsgBox("Transaction Saved")
            Try
                cmd.ExecuteNonQuery()
                cmd.Dispose()
                myconnection.Close()

            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged

        c_name = ComboBox1.Text


    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Me.Hide()
        Form2.Show()

    End Sub
End Class