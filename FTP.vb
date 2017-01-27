Public Class FTP
    Sub New()

    End Sub
    Private _FtpWebRequest As System.Net.FtpWebRequest
    Friend Property FtpWebRequest As System.Net.FtpWebRequest
        Get
            Return _FtpWebRequest
        End Get
        Private Set(value As System.Net.FtpWebRequest)
            _FtpWebRequest = value
        End Set
    End Property
    Private Function NetworkCredential() As System.Net.NetworkCredential
        Return New System.Net.NetworkCredential("", "")
    End Function
    Private _UploadFileName As String
    Friend Property UploadFileName As String
        Get
            Return _UploadFileName
        End Get
        Private Set(value As String)
            _UploadFileName = value
        End Set
    End Property
    Friend ReadOnly Property IsUploadFileExists() As Boolean
        Get
            Return IO.File.Exists(Me.UploadFileName)
        End Get
    End Property

    Friend Function UploadFile(m_UploadFileName As String) As Boolean
        Try
            UploadFileName = m_UploadFileName
            If IsUploadFileExists = False Then Throw New Exception("File not Exists for FTP Upload Check File: " & UploadFileName)



            Return True
        Catch ex As Exception
            Throw
        End Try
    End Function


End Class
