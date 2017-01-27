Imports System.IO.Compression
Imports System.IO
Public Class Meta
    Private _InFileInfo As IO.FileInfo
    Friend Property InFileInfo As IO.FileInfo
        Get
            Return _InFileInfo
        End Get
        Private Set(value As IO.FileInfo)
            _InFileInfo = value
        End Set
    End Property

    Private _OutFileInfo As IO.FileInfo
    Friend Property OutFileInfo As IO.FileInfo
        Get
            Return _OutFileInfo
        End Get
        Private Set(value As IO.FileInfo)
            _OutFileInfo = value
        End Set
    End Property
    Private _FileName As String
    Friend Property FileName As String
        Get
            Return _FileName
        End Get
        Private Set(value As String)
            _FileName = value
        End Set
    End Property
    Friend ReadOnly Property CompressionMode As CompressionMode
        Get
            If InFileInfo.Extension.ToUpper = CompressionExtension.ToUpper Then
                Return Compression.CompressionMode.Decompress
            Else
                Return Compression.CompressionMode.Compress
            End If
        End Get
    End Property
    Sub New(m_FileName As String)
        Try
            If IO.File.Exists(m_FileName) = False Then Throw New Exception("File Not found " & m_FileName)
            FileName = m_FileName
            InFileInfo = New FileInfo(FileName)
        Catch ex As Exception
            Throw
        End Try
    End Sub
    Friend ReadOnly Property CompressionExtension As String
        Get
            Return ".gz"
        End Get
    End Property

    Friend Function DoWork() As Boolean
        Try
            If CompressionMode = Compression.CompressionMode.Compress Then
                Return Compress()
            Else
                Return Decompress()
            End If
            Return True
        Catch ex As Exception
            Throw

        End Try
    End Function
    Private Function Compress() As Boolean
        Dim MyDestinationFile As String = InFileInfo.FullName & CompressionExtension
        Try
            Using inFile As FileStream = InFileInfo.OpenRead
                Using outFile As FileStream = File.Create(MyDestinationFile)
                    Using GZipStream As GZipStream = New GZipStream(outFile, CompressionMode.Compress)
                        inFile.CopyTo(GZipStream)
                    End Using
                End Using
            End Using
            Return True
        Catch ex As Exception
            Throw
        Finally
            If IO.File.Exists(MyDestinationFile) Then
                OutFileInfo = New FileInfo(MyDestinationFile)
            Else
                OutFileInfo = Nothing
            End If
        End Try
    End Function

    Private Function Decompress() As Boolean
        Dim MyDestinationFile As String = InFileInfo.FullName.Replace(CompressionExtension, "")
        Try
            Using inFile As FileStream = InFileInfo.OpenRead()
                Using outFile As FileStream = File.Create(MyDestinationFile)
                    Using GZipStream As GZipStream = New GZipStream(inFile, CompressionMode.Decompress)
                        GZipStream.CopyTo(outFile)
                    End Using
                End Using
            End Using
            Return True
        Catch ex As Exception
            Throw
        Finally

            If IO.File.Exists(MyDestinationFile) Then
                OutFileInfo = New FileInfo(MyDestinationFile)
            Else
                OutFileInfo = Nothing
            End If
        End Try

    End Function
End Class
