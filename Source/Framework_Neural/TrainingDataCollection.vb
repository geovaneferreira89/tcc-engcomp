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
'''This class is can hold a collection of training data objects
''' </summary>

Public Class TrainigDataCollection
    Inherits ArrayList

    Public Shadows Function Add(ByVal obj As TrainingData) As TrainingData
        MyBase.Add(obj)
        Add = obj
    End Function

    Public Shadows Function Add() As TrainingData
        Dim nl As New TrainingData()
        MyBase.Add(nl)
        Add = nl
    End Function

    Public Shadows Sub Insert(ByVal index As Integer, ByVal obj As TrainingData)
        MyBase.Insert(index, obj)
    End Sub

    Public Shadows Sub Remove(ByVal obj As TrainingData)
        MyBase.Remove(obj)
    End Sub

    Default Public Shadows Property Item(ByVal index As Integer) As TrainingData
        Get
            Item = DirectCast(MyBase.Item(index), TrainingData)
        End Get
        Set(ByVal Value As TrainingData)
            MyBase.Item(index) = Value
        End Set
    End Property
End Class