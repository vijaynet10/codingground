Imports System.Runtime.CompilerServices
Imports System.Windows.Forms
Imports System
Imports Microsoft.VisualBasic
Namespace Extensions
    Module ThreadExtensions
        Public Delegate Sub DelEnableButton(Button As Button)
        <Extension()> _
        Sub EnableButton(Button As Button)
            If Button.InvokeRequired Then
                Button.Invoke(New DelEnableButton(AddressOf EnableButton), {Button})
            Else
                Button.Enabled = True
            End If
        End Sub
        Public Delegate Sub DelDisableButton(Button As Button)
        <Extension()> _
        Sub DisableButton(Button As Button)
            If Button.InvokeRequired Then
                Button.Invoke(New DelDisableButton(AddressOf DisableButton), {Button})
            Else
                Button.Enabled = False
            End If
        End Sub
        Public Delegate Sub DelChangeLabelText(Label As Label, Text As String)
        <Extension()> _
        Public Sub ChangeLabelText(Label As Label, Text As String)
            If Label.InvokeRequired Then
                Label.Invoke(New DelChangeLabelText(AddressOf ChangeLabelText), {Label, Text})
            Else
                Label.Text = Text
            End If
        End Sub
        Public Delegate Sub DelProgressReset(PGBar As ProgressBar, Maximum As Integer)
        <Extension()> _
        Public Sub ProgressReset(PGBar As ProgressBar, Maximum As Integer)
            If PGBar.InvokeRequired Then
                PGBar.Invoke(New DelProgressReset(AddressOf ProgressReset), {PGBar, Maximum})
            Else
                PGBar.Value = 0
                PGBar.Maximum = Maximum
                PGBar.Step = 1
            End If
        End Sub

        Public Delegate Sub DelPBPerformSetp(PGBar As ProgressBar)
        <Extension()> _
        Public Sub ProgressPerformStep(PGBar As ProgressBar)
            If PGBar.InvokeRequired Then
                PGBar.Invoke(New DelPBPerformSetp(AddressOf ProgressPerformStep), {PGBar})
            Else
                PGBar.PerformStep()
            End If
        End Sub
        Public Delegate Function DelAddListItem(ListView As ListView, Text As String) As ListViewItem
        <Extension()> _
        Public Function AddListItem(ListView As ListView, Text As String) As ListViewItem
            If ListView.InvokeRequired Then
                Dim Obj As ListViewItem = ListView.Invoke(New DelAddListItem(AddressOf AddListItem), {ListView, Text})
                Return Obj
            Else
                Dim Obj As ListViewItem = ListView.Items.Add(Text)
                Obj.Selected = True
                Obj.Focused = True

                Return Obj
            End If
        End Function
        Public Delegate Sub DelChangeCursor(ByVal Form As Form, ByVal Cursor As Cursor)
        <Extension()> _
        Public Sub ChangeCurosr(ByVal Form As Form, ByVal Cursor As Cursor)
            If Form.InvokeRequired Then
                Form.Invoke(New DelChangeCursor(AddressOf ChangeCurosr), {Form, Cursor})
            Else
                Form.Cursor = Cursor
            End If
        End Sub
        Public Delegate Function DelGetString(Control As Control) As String
        <Extension()> _
        Public Function GetString(Control As Control) As String
            Try
                If Control.InvokeRequired Then
                    Dim ReturnValue As Object = Control.Invoke(New DelGetString(AddressOf GetString), {Control})
                    Return Convert.ToString(ReturnValue)
                Else
                    Return Convert.ToString(Control.Text)
                End If
            Catch ex As Exception
                Throw
            End Try
        End Function
        <Extension()> _
        Public Function IsThreadRunning(Thread As Threading.Thread) As Boolean

            If IsNothing(Thread) Then Return False
            If Thread.IsAlive = True Then
                Return True
            Else
                Return False
            End If
        End Function
        Public Delegate Sub DelDataGridSetDataSource(DataGrid As DataGridView, DT As Data.DataTable)
        <Extension()> _
        Public Sub DataGridSetDataSource(DataGrid As DataGridView, DT As Data.DataTable)
            Try
                If DataGrid.InvokeRequired Then
                    DataGrid.Invoke(New DelDataGridSetDataSource(AddressOf DataGridSetDataSource), {DataGrid, DT})
                Else
                    ''''  DataGrid.DataSource = Nothing
                    DataGrid.DataSource = DT
                End If
            Catch ex As Exception
                Throw
            End Try
        End Sub



    End Module
End Namespace
