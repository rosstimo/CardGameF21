Module CardGame

    Sub Main()
        DealCard()
        Console.Read()
    End Sub


    Sub debug(deck(,) As Boolean)
        Console.Clear()
        Dim mark As String
        For value = 0 To 12
            For suit = 0 To 3
                mark = "   |"
                If deck(suit, value) Then
                    mark = " X |"
                End If
                Console.Write(mark)
            Next
            Console.WriteLine()
        Next
    End Sub


    'TODO
    'Deal a card
    'Deal a Random valid card
    'Random number 0-3 suit, 0-12 {A, 2-10, J,Q,K}
    'Track the cards dealt
    'Function?
    '2D Array deck(suit, value)
    Sub DealCard()
        Dim suit As Integer = 3
        Dim value As Integer = 12
        Static deck(suit, value) As Boolean
        Dim userInput As String
        Dim count As Integer
        Do
            RandomCard(suit, value)
            If deck(suit, value) = False Then
                deck(suit, value) = True
                DisplayCard(suit, value)
                count += 1
            Else
                Console.WriteLine("dealt")
            End If
            userInput = Console.ReadLine()
            If userInput = "S" Or count >= 52 Then
                shuffle(deck)
                count = 0
            End If
            'debug(deck)
        Loop While userInput <> "Q"

    End Sub

    Sub RandomCard(ByRef suit As Integer, ByRef value As Integer)
        suit = RandomNumberInRange(3)
        value = RandomNumberInRange(12)
    End Sub

    'shuffle deck
    'Simply clear tracking data 

    Sub shuffle(ByRef deck(,) As Boolean)
        ReDim deck(3, 12)
        Console.WriteLine("Shuffle them cards!!")
    End Sub

    'Display card
    Function DisplayCard(suit As Integer, value As Integer) As String
        'Console.Clear()
        'Console.WriteLine($"{value} of {suit}")
        Console.WriteLine(PrettyCard(suit, value))
    End Function
    Function PrettyCard(suit As Integer, value As Integer) As String
        Dim _prettyCard As String

        Select Case value
            Case 0
                _prettyCard = "K"
            Case 1
                _prettyCard = "A"
            Case 2 To 10
                _prettyCard = CStr(value)
            Case 11
                _prettyCard = "J"
            Case 12
                _prettyCard = "Q"
        End Select

        Select Case suit
            Case 0
                _prettyCard &= " of Hearts"
            Case 1
                _prettyCard &= " of Clubs"
            Case 2
                _prettyCard &= " of Spades"
            Case 3
                _prettyCard &= " of Diamonds"
        End Select

        Return _prettyCard

    End Function

    ''' <summary>
    ''' The default range is 0 - 10.
    ''' The maximum number must be greater than minimum number.
    ''' </summary>
    ''' <param name="max%"></param>
    ''' <param name="min%"></param>
    ''' <returns>Returns a random integer within a range defined by the max and min arguments.</returns>
    ''' <exception cref="System.ArgumentException">Thrown when <c>max > min</c></exception>
    Function RandomNumberInRange(Optional max% = 10%, Optional min% = 0%) As Integer
        Dim _max% = max - min
        If _max <0 Then
            Throw New System.ArgumentException("Maximum number must be greater than minimum number")
        End If
        Randomize(DateTime.Now.Millisecond)
        Return CInt(System.Math.Floor(Rnd() * (_max + 1))) + min
    End Function
End Module
