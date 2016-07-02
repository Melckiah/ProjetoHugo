1 - Presentation Layer ou Camada de Apresenta��o
	-> Nesta camada devem ser desenvolvidos os projetos que s�o respons�veis
	 pela apresenta��o dos dados no sistema.
	-> Tipos de Projeto: Web, Mobile, Forms, Silverlight, OBA
2 - Application Layer ou Camada de Aplica��o	
	-> As regras de neg�cio (Services) bem como os padr�es de convers�o 
	dos (DTOs) s�o escritos nesta camada.
	-> Camada respons�vel por orquestrar o funcionamento do sistema
3 - Domain Layer ou Camada de Dominio
	-> Nesta camada devem ser desenvolvidos os objetos de neg�cio
	-> Objetos que representam o dom�nio l�gico da aplica��o.
	-> Interfaces de acesso aos reposit�rios de dados.
4 - Infrastructure Layer ou Camada de Infraestrutura ou Framework
	-> Nesta camada devem ser desenvolvidos os objetos que controlam o 
	acesso a dados, incluindo conex�es com a base de dados e comandos.
	-> As implenta��es das interfaces que definem o acesso aos bancos de 
	dados s�o implementados aqui: (classes para Access, classes para 
	SQL Server, classes para Oracle, classes para NHibernate, classes 
	para NoSQL).
	-> Nesta camada devem ser desenvolvidos os projetos que poder�o ser 
	utilizados por outros produtos, essa reutiliza��o de c�digo d� inicio
	ao framework da empresa.

