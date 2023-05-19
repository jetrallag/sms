Imports MySql.Data.MySqlClient
Public Class Signup
    Dim con As MySqlConnection
    Dim cnstr As String = "server=db4free.net; userid=joanneg20; password=JoanneGallarte20; database=smsystem; port=3306; old guids=true;"
    Dim cmd As MySqlCommand
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click

        Try
            con = New MySqlConnection(cnstr)
            con.Open()
            Dim sql As String = "Insert into login(,username,password) VALUES(,@uname,@pass)"
            cmd = New MySqlCommand(sql, con)
            cmd.Parameters.AddWithValue("@uname", usern.Text)
            cmd.Parameters.AddWithValue("@pass", passw.Text)
           
            Dim i As Integer = cmd.ExecuteNonQuery
            If i > 0 Then
                MsgBox("The Account Was Saved Successfully Registered!")
                usern.Clear()
                passw.Clear()

            Else
                MsgBox("The Account Cannot Be Saved!")
            End If
            con.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Login.Show()
        Me.Close()
    End Sub

    Private Function id() As Object
        Throw New NotImplementedException
    End Function

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
    Private Sub Label1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
End Class