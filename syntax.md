# 1. RGL Syntax

## 1.1 Top-level statements

```ANTLR
program
    : top_statement_group

top_statement_group
    : top_statement ';' top_statement_group
    | top_statement_block
    |
    ;

top_statement_block
    : '{' top_statement_group '}'
    | top_statement ';'
    ;

top_statement
    : rule_declaration
    | function_declaration
    | statement
    ;
```

### 1.1.1 Rule declaration

```ANTLR
rule_declaration
    : rule_identifier '->' statement_block
    ;

rule_statement_group
    : rule_statement ';' rule_statement_group
    | rule_statement_block
    |
    ;

rule_statement_block
    : '{' rule_statement_group '}'
    | rule_statement ';'
    ;

rule_statement
    : statement
    | condition_statement
    ;
```

### 1.1.2 Function declaration

```ANTLR
function_declaration
    : 'define' function_identifier '(' parameters ')' statement_block
    ;

parameters
    : parameter ',' parameters
    | parameter
    | 
    ;

parameter
    : variable_identifier
    ;
```

## 1.2 Statements

```ANTLR
statement
    : return_statement
    | any_assign_op
    ;

statement_group
    : statement ';' statement_group
    | statement_block
    |
    ;

statement_block
    : '{' statement_group '}'
    | statement ';'
    ;

return_statement
    : 'return' expression
    ;
```

## 1.3 Expressions

```ANTLR
expression
    : value
    | index_access
    | function_call
    | paren_expression
    | op_expression
    ;

cond_expression
    : expression 'if' expression
    ;

paren_expression
    : '(' expression ')'
    ;

value
    : integer
    | float
    | boolean
    | char
    | array
    | string
    | any_identifier
    ;

array
    : '[' cond_expression_args ']'
    ;

any_identifier
    : rule_identifier
    | variable_identifier
    | function_identifier
    ;

function_call
    : any_identifier '(' arguments ')'
    ;

arguments
    : expression ',' arguments
    | expression
    | 
    ;

cond_expression_args:
    : cond_expression ',' cond_expression_args
    | cond_expression
    |
    ;

index_access
    : value '[' expression ']'
    ;

scoped_variable
    : scope? variable_identifier
    ;

scope
    : 'global'
    : 'local'
    : 'context'
```

## 1.4 Operations

```ANTLR
op_expresion
    : aritmethic_op
    | logical_op
    | bitwise_op
    | any_assign_op
    ;
```

### 1.4.1 Aritmethic operations

```ANTLR
aritmethic_op
    : add_op
    | sub_op
    | minus_op
    | mult_op
    | div_op
    | pow_op
    | mod_op
    ;
```

```ANTLR
add_op
    : expression '+' expression
    ;

sub_op
    : expression '-' expression
    ;

minus_op
    : '-' expression
    ;

mult_op
    : expression '*' expression
    ;

div_op
    : expression '/' expression
    ;

pow_op
    : expression '**' expression
    ;

mod_op
    : expression '%' expression
    ;
```

### 1.4.2 Logical operations

```ANTLR
logical_op
    : equals_op
    | nequals_op
    | gequals_op
    | lequals_op
    | less_op
    | more_op
    | and_op
    | or_op
    | not_op
    | xor_op
    ;
```

```ANTLR
equals_op
    : expression '==' expression
    ;

nequals_op
    : expression '!=' expression
    ;

gequals_op
    : expression '>=' expression
    ;

lequals_op
    : expression '<=' expression
    ;

less_op
    : expression '<' expression
    ;

more_op
    : expression '>' expression
    ;

and_op
    : expression 'and' expression
    ;

or_op
    : expression 'or' expression
    ;

not_op
    : 'not' expression
    ;

xor_op
    : expression 'xor' expression
    ;
```

### 1.4.3 Bitwise operations

```ANTLR
bitwise_op
    : bitwise_and_op
    | bitwise_or_op
    | bitwise_not_op
    | bitwise_xor_op
    ;
```

```ANTLR
bitwise_and_op
    : expression '^' expression
    ;

bitwise_or_op
    : expression 'v' expression
    ;

bitwise_not_op
    : expression '¬' expression
    ;

bitwise_xor_op
    : expression 'bxor' expression
    ;
```

### 1.4.4 Assignment operations

```ANTLR
any_assign_op
    : assign_op
    : add_assign_op
    : sub_assign_op
    : power_assign_op
    : mult_assign_op
    : div_assign_op
    : modulo_assign_op
    ;
```

```ANTLR
assign_op
    : scoped_variable '=' expression
    ;

add_assign_op
    : scoped_variable '+=' expression
    ;

sub_assign_op
    : scoped_variable '-=' expression
    ;

power_assign_op
    : scoped_variable '**=' expression
    ;

mult_assign_op
    : scoped_variable '*=' expression
    ;

div_assign_op
    : scoped_variable '/=' expression
    ;

modulo_assign_op
    : scoped_variable '%=' expression
    ;
```

## 1.5 String