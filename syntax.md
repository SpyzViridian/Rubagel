# RGL Syntax

## Top-level


```ANTLR
program
    : statement_group

statement_group
    : statement ';' statement_group
    : statement_block
    | λ
    ;

statement_block
    : '{' statement_group '}' 
    ;
```
