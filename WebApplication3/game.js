var intBoard;
var BoardSize;
var max = Math.floor(screen.height / 50 - 3);

function GAMEboard() {
    BoardSize = prompt("Enter the size of the board" + "\n" + "Max size is " + max + "\n" + "Min size is 3");
    while (BoardSize > max || BoardSize < 3 || BoardSize == null || BoardSize == "" || BoardSize % 1 != 0) {
        BoardSize = prompt("Enter the size of the board" + "\n" + "Max size is " + max + "\n" + "Min size is 3");
    }

    //the number board used for checks
    intBoard = new Array(BoardSize);
    var r, c;
    for (r = 0; r < BoardSize; r++) {
        intBoard[r] = new Array(BoardSize);
        for (c = 0; c < BoardSize; c++) {
            intBoard[r][c] = 0;
        }
    }

    //building the game board
    var idNum = 0;
    var strToShow = "<table border='1' style='margin:auto;border-collapse:collapse'>";
    strToShow = strToShow + " <h1 class='center'> THE GAME STARTED: </h1>";
    for (var r = 0; r < BoardSize; r++) {
        strToShow = strToShow + "<tr>";
        for (var c = 0; c < BoardSize; c++) {
            strToShow = strToShow + "<td id='" + idNum.toString() +
                "' onclick='TdClicked(this)' width='50px' height='50px' >";

            if (r == 0 && c == BoardSize - 1) {
                strToShow = strToShow + "<img width='50px' height='50px' src='O.png'/>";
                intBoard[r][c] = 1;
            } else if (r == BoardSize - 1 && c == 0) {
                strToShow = strToShow + "<img width='50px' height='50px' src='O.png'/>";
                intBoard[r][c] = 1;
            }

            if (r == 0 && c == 0) {
                strToShow = strToShow + "<img width='50px' height='50px' src='X.png'/>";
                intBoard[r][c] = 2;
            } else if (r == BoardSize - 1 && c == BoardSize - 1) {
                strToShow = strToShow + "<img width='50px' height='50px' src='X.png'/>";
                intBoard[r][c] = 2;
            }

            strToShow = strToShow + "</td>";
            idNum++;
        }
        strToShow = strToShow + "</tr>";
    }
    strToShow = strToShow + "</table>";
    document.write(strToShow);
}

// starting the clicking actions
var First1Clicked;
var RedTurn = 0;
var f = 1;
var t;

function TdClicked(tdClickedThis) {
    var idClicked = tdClickedThis.id;
    var rowClicked = Math.floor(idClicked / BoardSize);
    var colClicked = idClicked % BoardSize;

    var rightcol = colClicked + 1;
    var leftcol = colClicked - 1;
    var upRow = rowClicked - 1;
    var downRow = rowClicked + 1;

    if (RedTurn < 2) {
        if ((RedTurn % 2) == 0) {
            //choose player (first click)
            if (intBoard[rowClicked][colClicked] == 1) {
                document.getElementById(idClicked).innerHTML = "<img width='37px' height='37px' src='O.png'/>";
                intBoard[rowClicked][colClicked] = 1;
                First1Clicked = idClicked;
            } else {
                alert("Illegal move");
                return;
            }
        } else {
            var FirstrowClicked = Math.floor(First1Clicked / BoardSize);
            var FirstcolClicked = First1Clicked % BoardSize;

            rightcol = FirstcolClicked + 1;
            leftcol = FirstcolClicked - 1;
            upRow = FirstrowClicked - 1;
            downRow = FirstrowClicked + 1;

            //move one spot to copy player
            if ((intBoard[rowClicked][colClicked] == 0 && colClicked == rightcol && rowClicked == downRow) ||
                (colClicked == leftcol && rowClicked == downRow) ||
                (colClicked == rightcol && rowClicked == upRow) ||
                (colClicked == leftcol && rowClicked == upRow) ||
                (colClicked == rightcol && rowClicked == FirstrowClicked) ||
                (colClicked == leftcol && rowClicked == FirstrowClicked) ||
                (rowClicked == downRow && colClicked == FirstcolClicked) ||
                (rowClicked == upRow && colClicked == FirstcolClicked)) {
                document.getElementById(idClicked).innerHTML = "<img width='50px' height='50px' src='O.png'/>";
                intBoard[rowClicked][colClicked] = 1;

                //making the first player normal
                document.getElementById(First1Clicked).innerHTML = "<img width='50px' height='50px' src='O.png'/>";
            } else {
                alert("Illegal move");
                return;
            }
        }
        t = 1;
        RedTurn = RedTurn + f;
        f++;
    } else {
        if ((RedTurn % 2) != 0) {
            //choose player (first click)
            if (intBoard[rowClicked][colClicked] == 2) {
                document.getElementById(idClicked).innerHTML = "<img width='37px' height='37px' src='X.png'/>";
                intBoard[rowClicked][colClicked] = 2;
                First1Clicked = idClicked;
            } else {
                alert("Illegal move");
                return;
            }
        } else {
            FirstrowClicked = Math.floor(First1Clicked / BoardSize);
            FirstcolClicked = First1Clicked % BoardSize;

            rightcol = FirstcolClicked + 1;
            leftcol = FirstcolClicked - 1;
            upRow = FirstrowClicked - 1;
            downRow = FirstrowClicked + 1;

            //move one spot to copy player
            if ((intBoard[rowClicked][colClicked] == 0 && colClicked == rightcol && rowClicked == downRow) ||
                (colClicked == leftcol && rowClicked == downRow) ||
                (colClicked == rightcol && rowClicked == upRow) ||
                (colClicked == leftcol && rowClicked == upRow) ||
                (colClicked == rightcol && rowClicked == FirstrowClicked) ||
                (colClicked == leftcol && rowClicked == FirstrowClicked) ||
                (rowClicked == downRow && colClicked == FirstcolClicked) ||
                (rowClicked == upRow && colClicked == FirstcolClicked)) {
                document.getElementById(idClicked).innerHTML = "<img width='50px' height='50px' src='X.png'/>";
                intBoard[rowClicked][colClicked] = 2;

                //making the first click normal
                document.getElementById(First1Clicked).innerHTML = "<img width='50px' height='50px' src='X.png'/>";
            } else {
                alert("Illegal move");
                return;
            }
        }
        f = 1;
        RedTurn = RedTurn - t;
        t++;
    }

    //check all the pieces around the place that was clicked and change the color of the pieces to O or X depends on the last piece placed
    if (intBoard[rowClicked][colClicked] == 1) {
        if (intBoard[upRow][colClicked] == 0) {
            document.getElementById(upRow * BoardSize + colClicked).innerHTML = "<img width='50px' height='50px' src='O.png'/>";
            intBoard[upRow][colClicked] = 1;
        }
        if (intBoard[downRow][colClicked] == 0) {
            document.getElementById(downRow * BoardSize + colClicked).innerHTML = "<img width='50px' height='50px' src='O.png'/>";
            intBoard[downRow][colClicked] = 1;
        }
        if (intBoard[rowClicked][rightcol] == 0) {
            document.getElementById(rowClicked * BoardSize + rightcol).innerHTML = "<img width='50px' height='50px' src='O.png'/>";
            intBoard[rowClicked][rightcol] = 1;
        }
        if (intBoard[rowClicked][leftcol] == 0) {
            document.getElementById(rowClicked * BoardSize + leftcol).innerHTML = "<img width='50px' height='50px' src='O.png'/>";
            intBoard[rowClicked][leftcol] = 1;
        }
    }
}

var Rcounter = 0;
var Bcounter = 0;

function CheckBlueWin() {
    for (var ro = 0; ro < BoardSize; ro++) {
        for (var co = 0; co < BoardSize; co++) {
            if (intBoard[ro][co] == 0) {
                return false;
            } else {
                if (intBoard[ro][co] == 1) {
                    Rcounter++;
                } else {
                    Bcounter++;
                }
            }
        }
    }

    if (Bcounter > Rcounter) {
        if (confirm("Red wins!\nDo you want to restart the game?")) {
            document.location.reload();
        }
    } else {
        if (confirm("Blue wins!\nDo you want to restart the game?")) {
            document.location.reload();
        }
    }
}
