grammar Calculadora;

script: comando (EOL comando)* EOL* EOF ;

comando: asignacion
       | expresion
       ;

asignacion : ID ASI expresion
           ;

expresion : expresion op=(SUM|RES) termino #sumORes
          | termino                        #terminoSolo
          ;

termino : termino op=(MUL|DIV) factor #mulODiv
        | factor                      #factorSolo
        ;

factor : NUM                      #numero
       | ID                       #identificador
       | LPAR expresion RPAR      #subexpresion
       ;

SUM : '+';
RES : '-';
MUL : '*';
DIV : '/';
LPAR: '(';
RPAR: ')';
ASI: '=' ;
EOL: '\r'? '\n' ;
NUM: [0-9]+ ( '.' [0-9]+ )? ;
ID: [A-Za-z_] [A-Za-z_0-9]* ;

WS: [ \t]+ -> skip ;