Public Class Form1

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If TextBox1.Text = "ninad" And TextBox2.Text = "ninad123" Then
            Me.Hide()
            Form2.Show()
        ElseIf TextBox1.Text = "mayur" And TextBox2.Text = "mayur123" Then
            Me.Hide()
            Form2.Show()
        Else
            MsgBox("Invalid Login details")
        End If

        

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()

    End Sub
End Class
