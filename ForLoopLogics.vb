Public Class ForLoopLogics
    Public Function ForLoop() As Integer
        Try
            Dim IntI As Integer = 1
            For IntI = 1 To 300
                Debug.Print(IntI)
            Next IntI
            Return IntI
        Catch ex As Exception
            Throw
        End Try
    End Function
    Public Function ForLoopStepExample(_ValueToreverse As String) As String
        Try
            Dim _ReverseValueToreverse As String = String.Empty
            For IntI As Integer = _ValueToreverse.Length - 1 To 0 Step -1
                _ReverseValueToreverse &= _ValueToreverse(IntI)
            Next
            Return _ReverseValueToreverse
        Catch ex As Exception
            Throw
        End Try
    End Function
    Public Function ForLoopExitFor(_Value As String) As Boolean
        Try
            Dim BlnFindA_Alpha As Boolean = False
            For IntI As Integer = 0 To _Value.Length - 1
                If _Value(IntI).ToString.ToUpper = "A" Then
                    BlnFindA_Alpha = True
                    Exit For
                End If
            Next
            Return BlnFindA_Alpha
        Catch ex As Exception
            Throw
        End Try
    End Function

End Class
