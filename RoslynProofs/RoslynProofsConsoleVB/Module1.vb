Imports System.IO

Module Module1

    Sub Main()

    End Sub

    Public Function SelectDataRows(ByVal sourceDataTable As DataTable, ByVal filterExpressionParameters() As String,
                                   ByVal filterExpressionParameterValues() As Object, ByVal selectionLogicalOperator As Object) As DataRow()
        Dim matchedDataRows() As DataRow
        Dim filterExpression As String

        ' Construct the filter expression string
        filterExpression = BuildFilter(sourceDataTable, filterExpressionParameters, filterExpressionParameterValues, selectionLogicalOperator)
        Return sourceDataTable.Select(filterExpression)
    End Function

    Private Function BuildFilter(sourceDataTable As DataTable, filterExpressionParameters() As String, filterExpressionParameterValues() As Object, selectionLogicalOperator As Object) As String
        Throw New NotImplementedException()
    End Function

    Private m_IsPerformanceLoggingOn As Boolean = True
    Public Function WriteLog(ByVal message As String) As Boolean
        If m_IsPerformanceLoggingOn Then
            ' RETURNS A STREAMWRITER
            Dim fi As StreamWriter = GetFile()
            If fi IsNot Nothing Then
                fi.Write(message)
                fi.Write(vbCrLf)
                fi.Flush()
                fi.Close()
                fi.Dispose()
                Return True
            Else
                Return False
            End If
        End If
    End Function

    Private Function GetFile() As StreamWriter
        Throw New NotImplementedException()
    End Function

    Public Function SetVisible(ByVal value As Object, ByVal targetType As System.Type, ByVal parameter As Object, ByVal culture As System.Globalization.CultureInfo) As Object

        Dim visible = False
        If (value = "AllocateTo") Then
            visible = True
        End If
        If (value = "Require") Then
            visible = True
        End If
        If (value = "IssueCount") Then
            visible = False
        End If

        Return visible
    End Function

    Public Function Convert(ByVal value As Object, ByVal targetType As System.Type, ByVal parameter As Object, ByVal culture As System.Globalization.CultureInfo) As String

        Dim ConvertValue As String = "not set"
        Select Case (parameter)
            Case "Allocate"
                ConvertValue = "someallocatemessage"
            Case "issue"
                ConvertValue = "someissuemessage"
            Case "opened"
                ConvertValue = "some opened message"
            Case Else
                ConvertValue = "default"
        End Select

        Return ConvertValue
    End Function
End Module
