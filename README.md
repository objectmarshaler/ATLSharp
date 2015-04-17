#ATL#: an ATL parser for .NET
ATL#, pronounced as “ATL Sharp”, is an ATL ([Atlas Transformation Language] [1]) parser written in C# for the .NET platform. It is implemented as an assembly and thus can easily be incorporated into other projects (in any .NET language).

### Description
The base parser was generated using the [Antlr] [2] parser generator. Antlr translates a so-called grammar into a parser/lexer. The grammar for the ATL language was created from its [BNF grammar] [3]. However, some changes were made to this original BNF.

Firstly, the “module” rule was expanded. It is now referencing separate rules for the source model, target model and transformation mode (i.e. sourceModelPattern, targetModelPattern and transformationMode). There might be more of these changes possible in other parts of the grammar, depending on your particular use case.

Secondly, in some places “IDENTIFIER” has been changed to the choice of an identifier or a string as some of the example transformations used during the development of the parser allowed both. This is a bit different than the concept of Identifer in other languages such as Java, C#. It is still unclear whether this applies to every instance though. If so, the grammar should be modified accordingly.

A small wrapper class, the “ATLTransformationParser”, was written to facilitate the parsing of ATL transformations. The parser can take either a filename or a stream as input (i.e. via the Parse method). Alternatively, a string can also be given as input (i.e. via the ParseString method). In both cases, a parse tree (syntax tree) is returned which can be traversed either manually or via a dedicated visitor. 

### Version
1.0.0

### Notes
- Please note that the same grammar that was used here could also be used to generate a similar Java parser for ATL.

### Version
3.0.2

## License
Apache 2.0

[1]:http://www.eclipse.org/atl/
[2]:http://www.antlr.org/
[3]:https://wiki.eclipse.org/M2M/ATL/Syntax
