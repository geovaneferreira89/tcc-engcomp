'------------------------------------------------------------------
' License Notice:
'------------------------------------------------------------------
' All Rights Reserved - Anoop Madhusudanan, 
' Mail: amazedsaint@gmail.com
' Website: http://amazedsaint.blogspot.com

' See my articles about BrainNet at 
' http://amazedsaint-articles.blogspot.com for details
'
' You can use this code (or part of it), for non 
' commercial and academic uses, as long as 
'   - You are keeping this notice along with it
'   - You are not making any profit out of this
'------------------------------------------------------------------

'''<summary> Exception from which other neural framework exceptions inherit </summary>
Public Class NeuralFrameworkException
    Inherits Exception

    Sub New(ByVal Message As String, ByVal e As Exception)
        MyBase.New(Message)

        '''Log the details if required'''
        Debug.Write(vbCrLf & "----------" & vbCrLf & "Error: " & Message & vbCrLf & "----------" & vbCrLf & e.StackTrace)
    End Sub


End Class
