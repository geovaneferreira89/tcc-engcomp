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

'''<summary>
'''This class provides a vector consists of inputs and outputs, for training
''' the network
'''</summary>
Public Class TrainingData

    Private _inputs As New ArrayList()
    Private _outputs As New ArrayList()

    Public ReadOnly Property Inputs() As ArrayList
        Get
            Return _inputs
        End Get
    End Property

    Public ReadOnly Property Outputs() As ArrayList
        Get
            Return _outputs
        End Get
    End Property

    Public Sub New()
        _inputs = New ArrayList()
        _outputs = New ArrayList()
    End Sub

    Public Sub New(ByVal input As ArrayList, ByVal output As ArrayList)
        _inputs = input
        _outputs = output
    End Sub



End Class
