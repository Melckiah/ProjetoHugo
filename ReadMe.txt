1 - Presentation Layer ou Camada de Apresentação
	-> Nesta camada devem ser desenvolvidos os projetos que são responsáveis
	 pela apresentação dos dados no sistema.
	-> Tipos de Projeto: Web, Mobile, Forms, Silverlight, OBA
2 - Application Layer ou Camada de Aplicação	
	-> As regras de negócio (Services) bem como os padrões de conversão 
	dos (DTOs) são escritos nesta camada.
	-> Camada responsável por orquestrar o funcionamento do sistema
3 - Domain Layer ou Camada de Dominio
	-> Nesta camada devem ser desenvolvidos os objetos de negócio
	-> Objetos que representam o domínio lógico da aplicação.
	-> Interfaces de acesso aos repositórios de dados.
4 - Infrastructure Layer ou Camada de Infraestrutura ou Framework
	-> Nesta camada devem ser desenvolvidos os objetos que controlam o 
	acesso a dados, incluindo conexões com a base de dados e comandos.
	-> As implentações das interfaces que definem o acesso aos bancos de 
	dados são implementados aqui: (classes para Access, classes para 
	SQL Server, classes para Oracle, classes para NHibernate, classes 
	para NoSQL).
	-> Nesta camada devem ser desenvolvidos os projetos que poderão ser 
	utilizados por outros produtos, essa reutilização de código dá inicio
	ao framework da empresa.

