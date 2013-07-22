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

'''<summary> An interface for a neural network factory </summary>
Public Interface INetworkFactory

    '''<summary> Create a neural Network. </summary>
    Function CreateNetwork(ByVal inputneurons As Long, ByVal outputneurons As Long) As INeuralNetwork

End Interface
