<?xml version="1.0"?>
<doc>
    <assembly>
        <name>SubSonic.Core</name>
    </assembly>
    <members>
        <member name="T:SubSonic.SqlGeneration.ISqlGenerator">
            <summary>
            
            </summary>
        </member>
        <member name="M:SubSonic.SqlGeneration.ISqlGenerator.GenerateCommandLine">
            <summary>
            Generates the command line.
            </summary>
            <returns></returns>
        </member>
        <member name="M:SubSonic.SqlGeneration.ISqlGenerator.GenerateConstraints">
            <summary>
            Generates the constraints.
            </summary>
            <returns></returns>
        </member>
        <member name="M:SubSonic.SqlGeneration.ISqlGenerator.GenerateFromList">
            <summary>
            Generates from list.
            </summary>
            <returns></returns>
        </member>
        <member name="M:SubSonic.SqlGeneration.ISqlGenerator.GenerateOrderBy">
            <summary>
            Generates the order by.
            </summary>
            <returns></returns>
        </member>
        <member name="M:SubSonic.SqlGeneration.ISqlGenerator.GenerateGroupBy">
            <summary>
            Generates the group by.
            </summary>
            <returns></returns>
        </member>
        <member name="M:SubSonic.SqlGeneration.ISqlGenerator.GenerateJoins">
            <summary>
            Generates the joins.
            </summary>
            <returns></returns>
        </member>
        <member name="M:SubSonic.SqlGeneration.ISqlGenerator.GetPagingSqlWrapper">
            <summary>
            Gets the paging SQL wrapper.
            </summary>
            <returns></returns>
        </member>
        <member name="M:SubSonic.SqlGeneration.ISqlGenerator.GetSelectColumns">
            <summary>
            Gets the select columns.
            </summary>
            <returns></returns>
        </member>
        <member name="M:SubSonic.SqlGeneration.ISqlGenerator.FindColumn(System.String)">
            <summary>
            Finds the column.
            </summary>
            <param name="columnName">Name of the column.</param>
            <returns></returns>
        </member>
        <member name="M:SubSonic.SqlGeneration.ISqlGenerator.BuildSelectStatement">
            <summary>
            Builds the select statement.
            </summary>
            <returns></returns>
        </member>
        <member name="M:SubSonic.SqlGeneration.ISqlGenerator.BuildPagedSelectStatement">
            <summary>
            Builds the paged select statement.
            </summary>
            <returns></returns>
        </member>
        <member name="M:SubSonic.SqlGeneration.ISqlGenerator.BuildUpdateStatement">
            <summary>
            Builds the update statement.
            </summary>
            <returns></returns>
        </member>
        <member name="M:SubSonic.SqlGeneration.ISqlGenerator.BuildInsertStatement">
            <summary>
            Builds the insert statement.
            </summary>
            <returns></returns>
        </member>
        <member name="M:SubSonic.SqlGeneration.ISqlGenerator.BuildDeleteStatement">
            <summary>
            Builds the delete statement.
            </summary>
            <returns></returns>
        </member>
        <member name="M:SubSonic.SqlGeneration.ISqlGenerator.SetInsertQuery(SubSonic.Query.Insert)">
            <summary>
            Sets the insert query.
            </summary>
            <param name="q">The q.</param>
        </member>
        <member name="P:SubSonic.SqlGeneration.ISqlGenerator.sqlFragment">
            <summary>
            SqlFragment. Field values may change depending on the inheriting Generator.
            </summary>
        </member>
        <member name="T:SubSonic.Query.Setting">
            <summary>
            
            </summary>
        </member>
        <member name="M:SubSonic.Query.Setting.EqualTo(System.Object)">
            <summary>
            Equals to.
            </summary>
            <param name="value">The value.</param>
            <returns></returns>
        </member>
        <member name="M:SubSonic.Query.Setting.Equals(System.Object)">
            <summary>
            Determines whether the specified <see cref="T:System.Object"/> is equal to the current <see cref="T:System.Object"/>.
            </summary>
            <param name="obj">The <see cref="T:System.Object"/> to compare with the current <see cref="T:System.Object"/>.</param>
            <returns>
            true if the specified <see cref="T:System.Object"/> is equal to the current <see cref="T:System.Object"/>; otherwise, false.
            </returns>
            <exception cref="T:System.NullReferenceException">The <paramref name="obj"/> parameter is null.</exception>
        </member>
        <member name="M:SubSonic.Query.Setting.GetHashCode">
            <summary>
            Serves as a hash function for a particular type.
            </summary>
            <returns>
            A hash code for the current <see cref="T:System.Object"/>.
            </returns>
        </member>
        <member name="M:SubSonic.Query.Setting.ToString">
            <summary>
            Returns a <see cref="T:System.String"/> that represents the current <see cref="T:System.Object"/>.
            </summary>
            <returns>
            A <see cref="T:System.String"/> that represents the current <see cref="T:System.Object"/>.
            </returns>
        </member>
        <member name="M:SubSonic.Query.Update.#ctor(System.String)">
            <summary>
            Initializes a new instance of the <see cref="T:SubSonic.Query.Update`1"/> class.
            </summary>
        </member>
        <member name="M:SubSonic.Query.Update.#ctor(SubSonic.Schema.ITable)">
            <summary>
            Initializes a new instance of the <see cref="T:SubSonic.Query.Update`1"/> class.
            </summary>
            <param name="table">The table.</param>
        </member>
        <member name="M:SubSonic.Query.Update.Set(System.String)">
            <summary>
            Sets the specified column name.
            </summary>
            <param name="columnName">Name of the column.</param>
            <returns></returns>
        </member>
        <member name="M:SubSonic.Query.Update.SetExpression(System.String)">
            <summary>
            Sets the expression.
            </summary>
            <param name="column">The column.</param>
            <returns></returns>
        </member>
        <member name="M:SubSonic.Query.Update.Execute">
            <summary>
            Executes this instance.
            </summary>
            <returns></returns>
        </member>
        <member name="T:SubSonic.Query.Update`1">
            <summary>
            
            </summary>
        </member>
        <member name="M:SubSonic.Query.Update`1.#ctor(SubSonic.DataProviders.IDataProvider)">
            <summary>
            Initializes a new instance of the <see cref="T:SubSonic.Query.Update`1"/> class.
            </summary>
            <param name="provider">The provider.</param>
        </member>
        <member name="M:SubSonic.Query.Update`1.Set(System.Linq.Expressions.Expression{System.Func{`0,System.Boolean}}[])">
            <summary>
            Sets the specified columns.
            </summary>
            <param name="columns">The columns.</param>
            <returns></returns>
        </member>
        <member name="T:SubSonic.Linq.Structure.ExpressionComparer">
            <summary>
            Compare two expressions to determine if they are equivalent
            </summary>
        </member>
        <member name="T:SubSonic.Linq.Translation.SubqueryRemover">
            <summary>
            Removes one or more SelectExpression's by rewriting the expression tree to not include them, promoting
            their from clause expressions and rewriting any column expressions that may have referenced them to now
            reference the underlying data directly.
            </summary>
        </member>
        <member name="T:SubSonic.Linq.Structure.DbExpressionVisitor">
            <summary>
            An extended expression visitor including custom DbExpression nodes
            </summary>
        </member>
        <member name="T:SubSonic.Linq.Translation.SkipRewriter">
            <summary>
            Rewrites take and skip expressions into uses of TSQL row_number function
            </summary>
        </member>
        <member name="P:SubSonic.DataProviders.IDataProvider.Schema">
            <summary>
            Holds list of tables, views, stored procedures, etc.
            </summary>
        </member>
        <member name="F:SubSonic.Repository.SimpleRepositoryOptions.None">
            <summary>
            An enumeration value for no options configured.
            </summary>
        </member>
        <member name="F:SubSonic.Repository.SimpleRepositoryOptions.Default">
            <summary>
            The default set of options (right now the same as none).
            </summary>
        </member>
        <member name="F:SubSonic.Repository.SimpleRepositoryOptions.RunMigrations">
            <summary>
            Use this flag to let the repository run migrations.
            </summary>
        </member>
        <member name="M:SubSonic.Repository.SimpleRepository.Single``1(System.Linq.Expressions.Expression{System.Func{``0,System.Boolean}})">
            <summary>
            Singles the specified expression.
            </summary>
            <typeparam name="T"></typeparam>
            <param name="expression">The expression.</param>
            <returns></returns>
        </member>
        <member name="M:SubSonic.Repository.SimpleRepository.Single``1(System.Object)">
            <summary>
            Singles the specified key.
            </summary>
            <typeparam name="T"></typeparam>
            <param name="key">The key.</param>
            <returns></returns>
        </member>
        <member name="M:SubSonic.Repository.SimpleRepository.Find``1(System.Linq.Expressions.Expression{System.Func{``0,System.Boolean}})">
            <summary>
            Retrieves subset of records from the database matching the expression
            </summary>
        </member>
        <member name="M:SubSonic.Repository.SimpleRepository.GetPaged``1(System.Int32,System.Int32)">
            <summary>
            Gets the paged.
            </summary>
            <typeparam name="T"></typeparam>
            <param name="pageIndex">Index of the page.</param>
            <param name="pageSize">Size of the page.</param>
            <returns></returns>
        </member>
        <member name="M:SubSonic.Repository.SimpleRepository.GetPaged``1(System.String,System.Int32,System.Int32)">
            <summary>
            Gets the paged.
            </summary>
            <typeparam name="T"></typeparam>
            <param name="sortBy">The sort by.</param>
            <param name="pageIndex">Index of the page.</param>
            <param name="pageSize">Size of the page.</param>
            <returns></returns>
        </member>
        <member name="M:SubSonic.Repository.SimpleRepository.Add``1(``0)">
            <summary>
            Adds the specified item, setting the key if available.
            </summary>
            <typeparam name="T"></typeparam>
            <param name="item">The item.</param>
            <returns></returns>
        </member>
        <member name="M:SubSonic.Repository.SimpleRepository.AddMany``1(System.Collections.Generic.IEnumerable{``0})">
            <summary>
            Adds a lot of the items using a transaction.
            </summary>
            <typeparam name="T"></typeparam>
            <param name="items">The items.</param>
        </member>
        <member name="M:SubSonic.Repository.SimpleRepository.Update``1(``0)">
            <summary>
            Updates the specified item.
            </summary>
            <typeparam name="T"></typeparam>
            <param name="item">The item.</param>
            <returns></returns>
        </member>
        <member name="M:SubSonic.Repository.SimpleRepository.UpdateMany``1(System.Collections.Generic.IEnumerable{``0})">
            <summary>
            Updates lots of items using a transaction.
            </summary>
            <typeparam name="T"></typeparam>
            <param name="items">The items.</param>
            <returns></returns>
        </member>
        <member name="M:SubSonic.Repository.SimpleRepository.Delete``1(System.Object)">
            <summary>
            Deletes the specified key.
            </summary>
            <typeparam name="T"></typeparam>
            <param name="key">The key.</param>
            <returns></returns>
        </member>
        <member name="M:SubSonic.Repository.SimpleRepository.DeleteMany``1(System.Linq.Expressions.Expression{System.Func{``0,System.Boolean}})">
            <summary>
            Deletes 1 or more items.
            </summary>
            <typeparam name="T"></typeparam>
            <param name="expression">The expression.</param>
            <returns></returns>
        </member>
        <member name="M:SubSonic.Repository.SimpleRepository.DeleteMany``1(System.Collections.Generic.IEnumerable{``0})">
            <summary>
            Deletes 1 or more items.
            </summary>
            <typeparam name="T"></typeparam>
            <param name="items">The items.</param>
            <returns></returns>
        </member>
        <member name="M:SubSonic.Repository.SimpleRepository.Migrate``1">
            <summary>
            Migrates this instance.
            </summary>
            <typeparam name="T"></typeparam>
        </member>
        <member name="T:SubSonic.Query.BatchQuery">
            <summary>
            A holder for 1 or more queries to be executed together
            </summary>
        </member>
        <member name="M:SubSonic.Query.BatchQuery.BuildSqlStatement">
            <summary>
            Builds the SQL statement.
            </summary>
            <returns></returns>
        </member>
        <member name="M:SubSonic.Query.BatchQuery.Execute">
            <summary>
            Executes this instance.
            </summary>
            <returns></returns>
        </member>
        <member name="M:SubSonic.Query.BatchQuery.ExecuteReader">
            <summary>
            Executes the queries in and returns a multiple result set reader.
            </summary>
            <returns></returns>
        </member>
        <member name="M:SubSonic.Query.BatchQuery.GetCommand">
            <summary>
            Gets a command containing all the queued queries.
            </summary>
            <returns></returns>
        </member>
        <member name="M:SubSonic.Query.BatchQuery.Queue(SubSonic.Query.ISqlQuery)">
            <summary>
            Queues the specified query.
            </summary>
            <param name="query">The query.</param>
        </member>
        <member name="M:SubSonic.Query.BatchQuery.Queue``1(System.Linq.IQueryable{``0})">
            <summary>
            Queues the specified query.
            </summary>
            <typeparam name="T"></typeparam>
            <param name="query">The query.</param>
        </member>
        <member name="M:SubSonic.Query.BatchQuery.QueueForTransaction(SubSonic.Query.ISqlQuery)">
            <summary>
            Queues a query for use in a transaction.
            </summary>
            <param name="qry">The qry.</param>
        </member>
        <member name="M:SubSonic.Query.BatchQuery.QueueForTransaction(SubSonic.Query.QueryCommand)">
            <summary>
            Queues a query for use in a transaction.
            </summary>
            <param name="cmd">The CMD.</param>
        </member>
        <member name="M:SubSonic.Query.BatchQuery.QueueForTransaction(System.String,System.Object[])">
            <summary>
            Queues a query for use in a transaction.
            </summary>
            <param name="sql">The SQL.</param>
            <param name="parameters">The parameters.</param>
        </member>
        <member name="M:SubSonic.Query.BatchQuery.ExecuteTransaction">
            <summary>
            Executes the transaction.
            </summary>
        </member>
        <member name="T:SubSonic.Linq.Structure.ExpressionReplacer">
            <summary>
            Replaces references to one specific instance of an expression node with another node
            </summary>
        </member>
        <member name="T:SubSonic.Linq.Structure.TSqlLanguage">
            <summary>
            TSQL specific QueryLanguage
            </summary>
        </member>
        <member name="T:SubSonic.Linq.Structure.QueryLanguage">
            <summary>
            Defines the language rules for the query provider
            </summary>
        </member>
        <member name="M:SubSonic.Linq.Structure.QueryLanguage.IsScalar(System.Type)">
            <summary>
            Determines whether the CLR type corresponds to a scalar data type in the query language
            </summary>
            <param name="type"></param>
            <returns></returns>
        </member>
        <member name="M:SubSonic.Linq.Structure.QueryLanguage.CanBeColumn(System.Linq.Expressions.Expression)">
            <summary>
            Determines whether the given expression can be represented as a column in a select expressionss
            </summary>
            <param name="expression"></param>
            <returns></returns>
        </member>
        <member name="M:SubSonic.Linq.Structure.QueryLanguage.Translate(System.Linq.Expressions.Expression)">
            <summary>
            Provides language specific query translation.  Use this to apply language specific rewrites or
            to make assertions/validations about the query.
            </summary>
            <param name="expression"></param>
            <returns></returns>
        </member>
        <member name="M:SubSonic.Linq.Structure.QueryLanguage.Format(System.Linq.Expressions.Expression)">
            <summary>
            Converts the query expression into text of this query language
            </summary>
            <param name="expression"></param>
            <returns></returns>
        </member>
        <member name="M:SubSonic.Linq.Structure.QueryLanguage.Parameterize(System.Linq.Expressions.Expression)">
            <summary>
            Determine which sub-expressions must be parameters
            </summary>
            <param name="expression"></param>
            <returns></returns>
        </member>
        <member name="T:SubSonic.Linq.Translation.Parameterizer">
            <summary>
            Converts user arguments into named-value parameters
            </summary>
        </member>
        <member name="P:SubSonic.Schema.IColumn.IsNumeric">
            <summary>
            Gets a value indicating whether this instance is numeric.
            </summary>
            <value>
            	<c>true</c> if this instance is numeric; otherwise, <c>false</c>.
            </value>
        </member>
        <member name="P:SubSonic.Schema.IColumn.IsDateTime">
            <summary>
            Gets a value indicating whether this instance is date time.
            </summary>
            <value>
            	<c>true</c> if this instance is date time; otherwise, <c>false</c>.
            </value>
        </member>
        <member name="P:SubSonic.Schema.IColumn.IsString">
            <summary>
            Gets a value indicating whether this instance is string.
            </summary>
            <value><c>true</c> if this instance is string; otherwise, <c>false</c>.</value>
        </member>
        <member name="P:SubSonic.Schema.DatabaseColumn.IsNumeric">
            <summary>
            Gets a value indicating whether this instance is numeric.
            </summary>
            <value>
            	<c>true</c> if this instance is numeric; otherwise, <c>false</c>.
            </value>
        </member>
        <member name="P:SubSonic.Schema.DatabaseColumn.IsDateTime">
            <summary>
            Gets a value indicating whether this instance is date time.
            </summary>
            <value>
            	<c>true</c> if this instance is date time; otherwise, <c>false</c>.
            </value>
        </member>
        <member name="P:SubSonic.Schema.DatabaseColumn.IsString">
            <summary>
            Gets a value indicating whether this instance is string.
            </summary>
            <value><c>true</c> if this instance is string; otherwise, <c>false</c>.</value>
        </member>
        <member name="T:SubSonic.Schema.DatabaseColumn.ReservedColumnName">
            <summary>
            Summary for the ReservedColumnName class
            </summary>
        </member>
        <member name="M:SubSonic.SqlGeneration.Schema.ISchemaGenerator.BuildCreateTableStatement(SubSonic.Schema.ITable)">
            <summary>
            Builds a CREATE TABLE statement.
            </summary>
            <param name="table"></param>
            <returns></returns>
        </member>
        <member name="M:SubSonic.SqlGeneration.Schema.ISchemaGenerator.BuildDropTableStatement(System.String)">
            <summary>
            Builds a DROP TABLE statement.
            </summary>
            <param name="tableName">Name of the table.</param>
            <returns></returns>
        </member>
        <member name="M:SubSonic.SqlGeneration.Schema.ISchemaGenerator.BuildAddColumnStatement(System.String,SubSonic.Schema.IColumn)">
            <summary>
            Adds the column.
            </summary>
            <param name="tableName">Name of the table.</param>
            <param name="column">The column.</param>
        </member>
        <member name="M:SubSonic.SqlGeneration.Schema.ISchemaGenerator.BuildAlterColumnStatement(SubSonic.Schema.IColumn)">
            <summary>
            Alters the column.
            </summary>
            <param name="column">The column.</param>
        </member>
        <member name="M:SubSonic.SqlGeneration.Schema.ISchemaGenerator.BuildDropColumnStatement(System.String,System.String)">
            <summary>
            Removes the column.
            </summary>
            <param name="tableName">Name of the table.</param>
            <param name="columnName">Name of the column.</param>
            <returns></returns>
        </member>
        <member name="M:SubSonic.SqlGeneration.Schema.ISchemaGenerator.GetNativeType(System.Data.DbType)">
            <summary>
            Gets the type of the native.
            </summary>
            <param name="dbType">Type of the db.</param>
            <returns></returns>
        </member>
        <member name="M:SubSonic.SqlGeneration.Schema.ISchemaGenerator.GenerateColumns(SubSonic.Schema.ITable)">
            <summary>
            Generates the columns.
            </summary>
            <param name="table">Table containing the columns.</param>
            <returns>
            SQL fragment representing the supplied columns.
            </returns>
        </member>
        <member name="M:SubSonic.SqlGeneration.Schema.ISchemaGenerator.GenerateColumnAttributes(SubSonic.Schema.IColumn)">
            <summary>
            Sets the column attributes.
            </summary>
            <param name="column">The column.</param>
            <returns></returns>
        </member>
        <member name="T:SubSonic.Query.IQuerySurface">
            <summary>
            </summary>
        </member>
        <member name="T:SubSonic.Query.Insert">
            <summary>
            
            </summary>
        </member>
        <member name="M:SubSonic.Query.Insert.#ctor">
            <summary>
            Initializes a new instance of the <see cref="T:SubSonic.Query.Insert"/> class.
            </summary>
        </member>
        <member name="M:SubSonic.Query.Insert.#ctor(SubSonic.DataProviders.IDataProvider)">
            <summary>
            Initializes a new instance of the <see cref="T:SubSonic.Query.Insert"/> class.
            </summary>
            <param name="provider">The provider.</param>
        </member>
        <member name="M:SubSonic.Query.Insert.BuildSqlStatement">
            <summary>
            Builds the SQL statement.
            </summary>
            <returns></returns>
        </member>
        <member name="M:SubSonic.Query.Insert.Into``1(System.String[])">
            <summary>
            Adds the specified columns into a new Insert object.
            </summary>
            <typeparam name="T"></typeparam>
            <param name="columns">The columns.</param>
            <returns></returns>
        </member>
        <member name="M:SubSonic.Query.Insert.Into``1(SubSonic.Schema.ITable)">
            <summary>
            Adds the specified columns into a new Insert object.
            </summary>
            <typeparam name="T"></typeparam>
            <param name="tbl">The TBL.</param>
            <returns></returns>
        </member>
        <member name="M:SubSonic.Query.Insert.Init">
            <summary>
            Inits this instance.
            </summary>
            <returns></returns>
        </member>
        <member name="M:SubSonic.Query.Insert.Value(System.String,System.Object)">
            <summary>
            Values the specified column.
            </summary>
            <param name="column">The column.</param>
            <param name="columnValue">The column value.</param>
            <returns></returns>
        </member>
        <member name="M:SubSonic.Query.Insert.Value(System.String,System.Object,System.Data.DbType)">
            <summary>
            Values the specified column.
            </summary>
            <param name="column">The column.</param>
            <param name="columnValue">The column value.</param>
            <param name="dbType">Type of the db.</param>
            <returns></returns>
        </member>
        <member name="M:SubSonic.Query.Insert.Values(System.Object[])">
            <summary>
            Valueses the specified values.
            </summary>
            <param name="values">The values.</param>
            <returns></returns>
        </member>
        <member name="M:SubSonic.Query.Insert.ValueExpression(System.Object[])">
            <summary>
            Values the expression.
            </summary>
            <param name="values">The values.</param>
            <returns></returns>
        </member>
        <member name="M:SubSonic.Query.Insert.ToString">
            <summary>
            Returns a <see cref="T:System.String"/> that represents the current <see cref="T:System.Object"/>.
            </summary>
            <returns>
            A <see cref="T:System.String"/> that represents the current <see cref="T:System.Object"/>.
            </returns>
        </member>
        <member name="M:SubSonic.Query.Insert.Execute">
            <summary>
            Executes this instance.
            </summary>
            <returns></returns>
        </member>
        <member name="T:SubSonic.Linq.Structure.TypeHelper">
            <summary>
            Type related helper methods
            </summary>
        </member>
        <member name="T:SubSonic.Linq.Structure.QueryCompiler">
            <summary>
            Creates a reusable, parameterized representation of a query that caches the execution plan
            </summary>
        </member>
        <member name="T:SubSonic.Linq.Structure.Grouping`2">
            <summary>
            Simple implementation of the IGrouping&lt;TKey, TElement&gt; interface
            </summary>
            <typeparam name="TKey"></typeparam>
            <typeparam name="TElement"></typeparam>
        </member>
        <member name="T:SubSonic.Linq.Translation.OrderByRewriter">
            <summary>
            Moves order-bys to the outermost select if possible
            </summary>
        </member>
        <member name="M:SubSonic.Linq.Translation.OrderByRewriter.PrependOrderings(System.Collections.Generic.IList{SubSonic.Linq.Structure.OrderExpression})">
            <summary>
            Add a sequence of order expressions to an accumulated list, prepending so as
            to give precedence to the new expressions over any previous expressions
            </summary>
            <param name="newOrderings"></param>
        </member>
        <member name="M:SubSonic.Linq.Translation.OrderByRewriter.RebindOrderings(System.Collections.Generic.IEnumerable{SubSonic.Linq.Structure.OrderExpression},SubSonic.Linq.Structure.TableAlias,System.Collections.Generic.HashSet{SubSonic.Linq.Structure.TableAlias},System.Collections.Generic.IEnumerable{SubSonic.Linq.Structure.ColumnDeclaration})">
            <summary>
            Rebind order expressions to reference a new alias and add to column declarations if necessary
            </summary>
        </member>
        <member name="T:SubSonic.Linq.Structure.QueryMapping">
            <summary>
            Defines mapping information and rules for the query provider
            </summary>
        </member>
        <member name="M:SubSonic.Linq.Structure.QueryMapping.IsEntity(System.Type)">
            <summary>
            Determines if a give CLR type is mapped as a database entity
            </summary>
            <param name="type"></param>
            <returns></returns>
        </member>
        <member name="M:SubSonic.Linq.Structure.QueryMapping.IsMapped(System.Reflection.MemberInfo)">
            <summary>
            Deterimines is a property is mapped onto a column or relationship
            </summary>
            <param name="member"></param>
            <returns></returns>
        </member>
        <member name="M:SubSonic.Linq.Structure.QueryMapping.IsColumn(System.Reflection.MemberInfo)">
            <summary>
            Determines if a property is mapped onto a column
            </summary>
            <param name="member"></param>
            <returns></returns>
        </member>
        <member name="M:SubSonic.Linq.Structure.QueryMapping.IsIdentity(System.Reflection.MemberInfo)">
            <summary>
            Determines if a property represents or is part of the entities unique identity (often primary key)
            </summary>
            <param name="member"></param>
            <returns></returns>
        </member>
        <member name="M:SubSonic.Linq.Structure.QueryMapping.IsRelationship(System.Reflection.MemberInfo)">
            <summary>
            Determines if a property is mapped as a relationship
            </summary>
            <param name="member"></param>
            <returns></returns>
        </member>
        <member name="M:SubSonic.Linq.Structure.QueryMapping.GetRelatedType(System.Reflection.MemberInfo)">
            <summary>
            The type of the entity on the other side of the relationship
            </summary>
            <param name="member"></param>
            <returns></returns>
        </member>
        <member name="M:SubSonic.Linq.Structure.QueryMapping.GetTableName(System.Type)">
            <summary>
            The name of the corresponding database table
            </summary>
            <param name="rowType"></param>
            <returns></returns>
        </member>
        <member name="M:SubSonic.Linq.Structure.QueryMapping.GetColumnName(System.Reflection.MemberInfo)">
            <summary>
            The name of the corresponding table column
            </summary>
            <param name="member"></param>
            <returns></returns>
        </member>
        <member name="M:SubSonic.Linq.Structure.QueryMapping.GetMappedMembers(System.Type)">
            <summary>
            A sequence of all the mapped members
            </summary>
            <param name="rowType"></param>
            <returns></returns>
        </member>
        <member name="M:SubSonic.Linq.Structure.QueryMapping.IsSingletonRelationship(System.Reflection.MemberInfo)">
            <summary>
            Determines if a relationship property refers to a single optional entity (as opposed to a collection.)
            </summary>
            <param name="member"></param>
            <returns></returns>
        </member>
        <member name="M:SubSonic.Linq.Structure.QueryMapping.GetTableQuery(System.Type)">
            <summary>
            Get a query expression that selects all entities from a table
            </summary>
            <param name="rowType"></param>
            <returns></returns>
        </member>
        <member name="M:SubSonic.Linq.Structure.QueryMapping.GetTypeProjection(System.Linq.Expressions.Expression,System.Type)">
            <summary>
            Gets an expression that constructs an entity instance relative to a root.
            The root is most often a TableExpression, but may be any other experssion such as
            a ConstantExpression.
            </summary>
            <param name="root"></param>
            <param name="type"></param>
            <returns></returns>
        </member>
        <member name="M:SubSonic.Linq.Structure.QueryMapping.GetAssociationKeys(System.Reflection.MemberInfo,System.Collections.Generic.List{System.Reflection.MemberInfo}@,System.Collections.Generic.List{System.Reflection.MemberInfo}@)">
            <summary>
            Get the members for the key properities to be joined in an association relationship
            </summary>
            <param name="association"></param>
            <param name="declaredTypeMembers"></param>
            <param name="associatedMembers"></param>
        </member>
        <member name="M:SubSonic.Linq.Structure.QueryMapping.GetMemberExpression(System.Linq.Expressions.Expression,System.Reflection.MemberInfo)">
            <summary>
            Get an expression for a mapped property relative to a root expression. 
            The root is either a TableExpression or an expression defining an entity instance.
            </summary>
            <param name="root"></param>
            <param name="member"></param>
            <returns></returns>
        </member>
        <member name="M:SubSonic.Linq.Structure.QueryMapping.GetAggregator(System.Type,System.Type)">
            <summary>
            Get a function that coerces an a sequence of one type into another type.
            This is primarily used for aggregators stored in ProjectionExpression's, which are used to represent the
            final transformation of the entire result set of a query.
            </summary>
            <param name="expectedType">The expected type.</param>
            <param name="actualType">The actual type.</param>
            <returns></returns>
        </member>
        <member name="M:SubSonic.Linq.Structure.QueryMapping.Translate(System.Linq.Expressions.Expression)">
            <summary>
            Apply mapping translations to this expression
            </summary>
            <param name="expression"></param>
            <returns></returns>
        </member>
        <member name="P:SubSonic.Linq.Structure.QueryMapping.Language">
            <summary>
            The language related to the mapping
            </summary>
        </member>
        <member name="M:SubSonic.Schema.DatabaseSchema.Empty">
            <summary>
            Returns Schema instance with empty lists.
            </summary>
        </member>
        <member name="M:SubSonic.Repository.TestRepository`1.BuildDeleteQuery(`0)">
            <summary>
            Builds the delete query.
            </summary>
            <param name="item">The item.</param>
            <returns></returns>
        </member>
        <member name="M:SubSonic.Repository.TestRepository`1.BuildInsertQuery(`0)">
            <summary>
            Builds the insert query.
            </summary>
            <param name="item">The item.</param>
            <returns></returns>
        </member>
        <member name="M:SubSonic.Repository.TestRepository`1.BuildUpdateQuery(`0)">
            <summary>
            Builds the update query.
            </summary>
            <param name="item">The item.</param>
            <returns></returns>
        </member>
        <member name="T:SubSonic.Linq.Structure.IQueryText">
            <summary>
            Optional interface for IQueryProvider to implement Query&lt;T&gt;'s QueryText property.
            </summary>
        </member>
        <member name="T:SubSonic.Linq.Structure.Query`1">
            <summary>
            A default implementation of IQueryable for use with QueryProvider
            </summary>
        </member>
        <member name="T:SubSonic.Linq.Translation.RedundantSubqueryRemover">
            <summary>
            Removes select expressions that don't add any additional semantic value
            </summary>
        </member>
        <member name="T:SubSonic.Linq.Translation.CrossApplyRewriter">
            <summary>
            Attempts to rewrite cross-apply and outer-apply joins as inner and left-outer joins
            </summary>
        </member>
        <member name="T:SubSonic.Linq.Translation.ProjectedColumns">
            <summary>
            Result from calling ColumnProjector.ProjectColumns
            </summary>
        </member>
        <member name="T:SubSonic.Linq.Translation.ColumnProjector">
            <summary>
            Splits an expression into two parts
              1) a list of column declarations for sub-expressions that must be evaluated on the server
              2) a expression that describes how to combine/project the columns back together into the correct result
            </summary>
        </member>
        <member name="T:SubSonic.Linq.Translation.ColumnProjector.Nominator">
            <summary>
            Nominator is a class that walks an expression tree bottom up, determining the set of 
            candidate expressions that are possible columns of a select expression
            </summary>
        </member>
        <member name="M:SubSonic.Extensions.ExpressionParser.ProcessExpression(System.Linq.Expressions.Expression)">
            <summary>
            Process the passed-in LINQ expression
            </summary>
            <param name="expression"></param>
        </member>
        <member name="T:SubSonic.SqlGeneration.Schema.ANSISchemaGenerator">
            <summary>
            A schema generator for your DB
            </summary>
        </member>
        <member name="M:SubSonic.SqlGeneration.Schema.ANSISchemaGenerator.BuildCreateTableStatement(SubSonic.Schema.ITable)">
            <summary>
            Builds a CREATE TABLE statement.
            </summary>
            <param name="table"></param>
            <returns></returns>
        </member>
        <member name="M:SubSonic.SqlGeneration.Schema.ANSISchemaGenerator.BuildDropTableStatement(System.String)">
            <summary>
            Builds a DROP TABLE statement.
            </summary>
            <param name="tableName">Name of the table.</param>
            <returns></returns>
        </member>
        <member name="M:SubSonic.SqlGeneration.Schema.ANSISchemaGenerator.BuildAddColumnStatement(System.String,SubSonic.Schema.IColumn)">
            <summary>
            Adds the column.
            </summary>
            <param name="tableName">Name of the table.</param>
            <param name="column">The column.</param>
            <returns></returns>
        </member>
        <member name="M:SubSonic.SqlGeneration.Schema.ANSISchemaGenerator.BuildAlterColumnStatement(SubSonic.Schema.IColumn)">
            <summary>
            Alters the column.
            </summary>
            <param name="column">The column.</param>
        </member>
        <member name="M:SubSonic.SqlGeneration.Schema.ANSISchemaGenerator.BuildDropColumnStatement(System.String,System.String)">
            <summary>
            Removes the column.
            </summary>
            <param name="tableName">Name of the table.</param>
            <param name="columnName">Name of the column.</param>
            <returns></returns>
        </member>
        <member name="M:SubSonic.SqlGeneration.Schema.ANSISchemaGenerator.GetNativeType(System.Data.DbType)">
            <summary>
            Gets the type of the native.
            </summary>
            <param name="dbType">Type of the db.</param>
            <returns></returns>
        </member>
        <member name="M:SubSonic.SqlGeneration.Schema.ANSISchemaGenerator.GenerateColumns(SubSonic.Schema.ITable)">
            <summary>
            Generates the columns.
            </summary>
            <param name="table">Table containing the columns.</param>
            <returns>
            SQL fragment representing the supplied columns.
            </returns>
        </member>
        <member name="M:SubSonic.SqlGeneration.Schema.ANSISchemaGenerator.GenerateColumnAttributes(SubSonic.Schema.IColumn)">
            <summary>
            Sets the column attributes.
            </summary>
            <param name="column">The column.</param>
            <returns></returns>
        </member>
        <member name="M:SubSonic.SqlGeneration.Schema.ANSISchemaGenerator.GetTableFromDB(SubSonic.DataProviders.IDataProvider,System.String)">
            <summary>
            Gets an ITable from the DB based on name
            </summary>
        </member>
        <member name="M:SubSonic.SqlGeneration.Schema.ANSISchemaGenerator.GetTableList(SubSonic.DataProviders.IDataProvider)">
            <summary>
            Creates a list of table names
            </summary>
        </member>
        <member name="M:SubSonic.SqlGeneration.Schema.SQLiteSchema.GenerateColumnAttributes(SubSonic.Schema.IColumn)">
            <summary>
            Sets the column attributes.
            </summary>
            <param name="column">The column.</param>
            <returns></returns>
        </member>
        <member name="M:SubSonic.SqlGeneration.Schema.SQLiteSchema.GetDbType(System.String)">
            <summary>
            Gets the type of the db.
            </summary>
            <param name="sqlType">Type of the SQL.</param>
            <returns></returns>
        </member>
        <member name="T:SubSonic.Linq.Structure.RootQueryableFinder">
            <summary>
            Finds the first sub-expression that accesses a Query&lt;T&gt; object
            </summary>
        </member>
        <member name="M:SubSonic.Schema.StoredProcedure.Execute">
            <summary>
            Executes the specified SQL.
            </summary>
        </member>
        <member name="M:SubSonic.Schema.StoredProcedure.ExecuteScalar``1">
            <summary>
            Executes the scalar.
            </summary>
            <typeparam name="TResult">The type of the result.</typeparam>
            <returns></returns>
        </member>
        <member name="M:SubSonic.Schema.StoredProcedure.ExecuteTypedList``1">
            <summary>
            Executes the typed list.
            </summary>
            <typeparam name="T"></typeparam>
            <returns></returns>
        </member>
        <member name="M:SubSonic.Schema.StoredProcedure.ExecuteReader">
            <summary>
            Executes the reader.
            </summary>
            <returns></returns>
        </member>
        <member name="M:SubSonic.SqlGeneration.Schema.MySqlSchema.GetNativeType(System.Data.DbType)">
            <summary>
            Gets the type of the native.
            </summary>
            <param name="dbType">Type of the db.</param>
            <returns></returns>
        </member>
        <member name="M:SubSonic.SqlGeneration.Schema.MySqlSchema.GenerateColumns(SubSonic.Schema.ITable)">
            <summary>
            Generates the columns.
            </summary>
            <param name="table">Table containing the columns.</param>
            <returns>
            SQL fragment representing the supplied columns.
            </returns>
        </member>
        <member name="M:SubSonic.SqlGeneration.Schema.MySqlSchema.BuildCreateTableStatement(SubSonic.Schema.ITable)">
            <summary>
            Builds a CREATE TABLE statement.
            </summary>
            <param name="table"></param>
            <returns></returns>
        </member>
        <member name="M:SubSonic.SqlGeneration.Schema.MySqlSchema.GenerateColumnAttributes(SubSonic.Schema.IColumn)">
            <summary>
            Sets the column attributes.
            </summary>
            <param name="column">The column.</param>
            <returns></returns>
        </member>
        <member name="M:SubSonic.SqlGeneration.Schema.MySqlSchema.GetDbType(System.String)">
            <summary>
            Gets the type of the db.
            </summary>
            <param name="mySqlType">Type of my SQL.</param>
            <returns></returns>
        </member>
        <member name="T:SubSonic.SqlGeneration.MySqlGenerator">
            <summary>
            
            </summary>
        </member>
        <member name="T:SubSonic.SqlGeneration.ANSISqlGenerator">
            <summary>
            
            </summary>
        </member>
        <member name="M:SubSonic.SqlGeneration.ANSISqlGenerator.#ctor(SubSonic.Query.SqlQuery)">
            <summary>
            Initializes a new instance of the <see cref="T:SubSonic.SqlGeneration.ANSISqlGenerator"/> class.
            </summary>
            <param name="q">The q.</param>
        </member>
        <member name="M:SubSonic.SqlGeneration.ANSISqlGenerator.SetInsertQuery(SubSonic.Query.Insert)">
            <summary>
            Sets the insert query.
            </summary>
            <param name="q">The q.</param>
        </member>
        <member name="M:SubSonic.SqlGeneration.ANSISqlGenerator.FindColumn(System.String)">
            <summary>
            Finds the column.
            </summary>
            <param name="columnName">Name of the column.</param>
            <returns></returns>
        </member>
        <member name="M:SubSonic.SqlGeneration.ANSISqlGenerator.GenerateGroupBy">
            <summary>
            Generates the group by.
            </summary>
            <returns></returns>
        </member>
        <member name="M:SubSonic.SqlGeneration.ANSISqlGenerator.GenerateCommandLine">
            <summary>
            Generates the command line.
            </summary>
            <returns></returns>
        </member>
        <member name="M:SubSonic.SqlGeneration.ANSISqlGenerator.GenerateJoins">
            <summary>
            Generates the joins.
            </summary>
            <returns></returns>
        </member>
        <member name="M:SubSonic.SqlGeneration.ANSISqlGenerator.GenerateFromList">
            <summary>
            Generates from list.
            </summary>
            <returns></returns>
        </member>
        <member name="M:SubSonic.SqlGeneration.ANSISqlGenerator.GenerateConstraints">
            <summary>
            Generates the constraints.
            </summary>
            <returns></returns>
        </member>
        <member name="M:SubSonic.SqlGeneration.ANSISqlGenerator.GenerateOrderBy">
            <summary>
            Generates the order by.
            </summary>
            <returns></returns>
        </member>
        <member name="M:SubSonic.SqlGeneration.ANSISqlGenerator.GetSelectColumns">
            <summary>
            Gets the select columns.
            </summary>
            <returns></returns>
        </member>
        <member name="M:SubSonic.SqlGeneration.ANSISqlGenerator.GetPagingSqlWrapper">
            <summary>
            Gets the paging SQL wrapper.
            </summary>
            <returns></returns>
        </member>
        <member name="M:SubSonic.SqlGeneration.ANSISqlGenerator.BuildPagedSelectStatement">
            <summary>
            Builds the paged select statement.
            </summary>
            <returns></returns>
        </member>
        <member name="M:SubSonic.SqlGeneration.ANSISqlGenerator.BuildSelectStatement">
            <summary>
            Builds the select statement.
            </summary>
            <returns></returns>
        </member>
        <member name="M:SubSonic.SqlGeneration.ANSISqlGenerator.BuildUpdateStatement">
            <summary>
            Builds the update statement.
            </summary>
            <returns></returns>
        </member>
        <member name="M:SubSonic.SqlGeneration.ANSISqlGenerator.BuildInsertStatement">
            <summary>
            Builds the insert statement.
            </summary>
            <returns></returns>
        </member>
        <member name="M:SubSonic.SqlGeneration.ANSISqlGenerator.BuildDeleteStatement">
            <summary>
            Builds the delete statement.
            </summary>
            <returns></returns>
        </member>
        <member name="M:SubSonic.SqlGeneration.ANSISqlGenerator.QualifyTableName(SubSonic.Schema.ITable)">
            <summary>
            Qualifies the name of the table.
            </summary>
            <param name="tbl">The TBL.</param>
            <returns></returns>
        </member>
        <member name="M:SubSonic.SqlGeneration.ANSISqlGenerator.GetQualifiedSelect(SubSonic.Schema.ITable)">
            <summary>
            Gets the qualified select.
            </summary>
            <param name="table">The table.</param>
            <returns></returns>
        </member>
        <member name="M:SubSonic.SqlGeneration.ANSISqlGenerator.GenerateSelectColumnList">
            <summary>
            Generates the select column list.
            </summary>
            <returns></returns>
        </member>
        <member name="M:SubSonic.SqlGeneration.ANSISqlGenerator.BuildAggregateCommands">
            <summary>
            Builds the aggregate commands.
            </summary>
            <returns></returns>
        </member>
        <member name="M:SubSonic.SqlGeneration.ANSISqlGenerator.GenerateAggregateSelect(SubSonic.Query.Aggregate)">
            <summary>
            Generates the 'SELECT' part of an <see cref="T:SubSonic.Query.Aggregate"/>
            </summary>
            <param name="aggregate">The aggregate to include in the SELECT clause</param>
            <returns>The portion of the SELECT clause represented by this <see cref="T:SubSonic.Query.Aggregate"/></returns>
            <remarks>
            The ToString() logic moved from <see cref="M:SubSonic.Query.Aggregate.ToString"/>, rather than
            including it in the Aggregate class itself...
            </remarks>
        </member>
        <member name="M:SubSonic.SqlGeneration.MySqlGenerator.#ctor(SubSonic.Query.SqlQuery)">
            <summary>
            Initializes a new instance of the <see cref="T:SubSonic.SqlGeneration.MySqlGenerator"/> class.
            </summary>
            <param name="query">The query.</param>
        </member>
        <member name="M:SubSonic.SqlGeneration.MySqlGenerator.GetNativeType(System.Data.DbType)">
            <summary>
            Gets the type of the native.
            </summary>
            <param name="dbType">Type of the db.</param>
            <returns></returns>
        </member>
        <member name="M:SubSonic.SqlGeneration.MySqlGenerator.GenerateColumns(SubSonic.Schema.ITable)">
            <summary>
            Generates SQL for all the columns in table
            </summary>
            <param name="table">Table containing the columns.</param>
            <returns>
            SQL fragment representing the supplied columns.
            </returns>
        </member>
        <member name="M:SubSonic.SqlGeneration.MySqlGenerator.GenerateFromList">
            <summary>
            Generates from list.
            </summary>
            <returns></returns>
        </member>
        <member name="M:SubSonic.SqlGeneration.MySqlGenerator.GenerateColumnAttributes(SubSonic.Schema.IColumn)">
            <summary>
            Sets the column attributes.
            </summary>
            <param name="column">The column.</param>
            <returns></returns>
        </member>
        <member name="M:SubSonic.SqlGeneration.MySqlGenerator.BuildPagedSelectStatement">
            <summary>
            Builds the paged select statement.
            </summary>
            <returns></returns>
        </member>
        <member name="T:SubSonic.Linq.Structure.DbQueryProvider">
            <summary>
            A LINQ IQueryable query provider that executes database queries over a DbConnection
            </summary>
        </member>
        <member name="T:SubSonic.Linq.Structure.QueryProvider">
            <summary>
            A basic abstract LINQ query provider
            </summary>
        </member>
        <member name="M:SubSonic.Linq.Structure.DbQueryProvider.#ctor(SubSonic.DataProviders.IDataProvider,SubSonic.Linq.Structure.QueryPolicy,System.IO.TextWriter)">
            <summary>
            DbQueryProvider constrcutor that allows for external control of policy
            to allow for new types of databases.
            </summary>
        </member>
        <member name="M:SubSonic.Linq.Structure.DbQueryProvider.GetQueryText(System.Linq.Expressions.Expression)">
            <summary>
            Converts the query expression into text that corresponds to the command that would be executed.
            Useful for debugging.
            </summary>
            <param name="expression"></param>
            <returns></returns>
        </member>
        <member name="M:SubSonic.Linq.Structure.DbQueryProvider.Execute(System.Linq.Expressions.Expression)">
            <summary>
            Execute the query expression (does translation, etc.)
            </summary>
            <param name="expression"></param>
            <returns></returns>
        </member>
        <member name="M:SubSonic.Linq.Structure.DbQueryProvider.GetExecutionPlan(System.Linq.Expressions.Expression)">
            <summary>
            Convert the query expression into an execution plan
            </summary>
            <param name="expression"></param>
            <returns></returns>
        </member>
        <member name="M:SubSonic.Linq.Structure.DbQueryProvider.Translate(System.Linq.Expressions.Expression)">
            <summary>
            Do all query translations execpt building the execution plan
            </summary>
            <param name="expression"></param>
            <returns></returns>
        </member>
        <member name="M:SubSonic.Linq.Structure.DbQueryProvider.CanBeEvaluatedLocally(System.Linq.Expressions.Expression)">
            <summary>
            Determines whether a given expression can be executed locally. 
            (It contains no parts that should be translated to the target environment.)
            </summary>
            <param name="expression"></param>
            <returns></returns>
        </member>
        <member name="M:SubSonic.Linq.Structure.DbQueryProvider.Execute``1(SubSonic.Linq.Structure.QueryCommand{``0},System.Object[])">
            <summary>
            Execute an actual query specified in the target language using the sADO connection
            </summary>
            <typeparam name="T"></typeparam>
            <param name="query"></param>
            <param name="paramValues"></param>
            <returns></returns>
        </member>
        <member name="M:SubSonic.Linq.Structure.DbQueryProvider.Project``1(System.Data.Common.DbDataReader,System.Func{System.Data.Common.DbDataReader,``0})">
            <summary>
            Converts a data reader into a sequence of objects using a projector function on each row
            </summary>
            <typeparam name="T"></typeparam>
            <param name="reader">The reader.</param>
            <param name="fnProjector">The fn projector.</param>
            <returns></returns>
        </member>
        <member name="M:SubSonic.Linq.Structure.DbQueryProvider.ExecuteDeferred``1(SubSonic.Linq.Structure.QueryCommand{``0},System.Object[])">
            <summary>
            Get an IEnumerable that will execute the specified query when enumerated
            </summary>
            <typeparam name="T"></typeparam>
            <param name="query"></param>
            <param name="paramValues"></param>
            <returns></returns>
        </member>
        <member name="M:SubSonic.Linq.Structure.DbQueryProvider.GetCommand(System.String,System.Collections.Generic.IList{System.String},System.Object[])">
            <summary>
            Get an ADO command object initialized with the command-text and parameters
            </summary>
            <param name="commandText"></param>
            <param name="paramNames"></param>
            <param name="paramValues"></param>
            <returns></returns>
        </member>
        <member name="M:SubSonic.Linq.Structure.DbQueryProvider.LogCommand(System.Data.Common.DbCommand)">
            <summary>
            Write a command to the log
            </summary>
            <param name="command"></param>
        </member>
        <member name="M:SubSonic.Extensions.Objects.ChangeTypeTo``1(System.Object)">
            <summary>
            Returns an Object with the specified Type and whose value is equivalent to the specified object.
            </summary>
            <param name="value">An Object that implements the IConvertible interface.</param>
            <returns>
            An object whose Type is conversionType (or conversionType's underlying type if conversionType
            is Nullable&lt;&gt;) and whose value is equivalent to value. -or- a null reference, if value is a null
            reference and conversionType is not a value type.
            </returns>
            <remarks>
            This method exists as a workaround to System.Convert.ChangeType(Object, Type) which does not handle
            nullables as of version 2.0 (2.0.50727.42) of the .NET Framework. The idea is that this method will
            be deleted once Convert.ChangeType is updated in a future version of the .NET Framework to handle
            nullable types, so we want this to behave as closely to Convert.ChangeType as possible.
            This method was written by Peter Johnson at:
            http://aspalliance.com/author.aspx?uId=1026.
            </remarks>
            
        </member>
        <member name="T:SubSonic.SqlGeneration.SqlFragment">
            <summary>
            Summary for the SqlFragment class
            </summary>
        </member>
        <member name="T:SubSonic.Schema.DatabaseTable.TableType">
            <summary>
            
            </summary>
        </member>
        <member name="F:SubSonic.Schema.DatabaseTable.TableType.Table">
            <summary>
            
            </summary>
        </member>
        <member name="F:SubSonic.Schema.DatabaseTable.TableType.View">
            <summary>
            
            </summary>
        </member>
        <member name="T:SubSonic.Query.TypeSystem">
            <summary>
            Type related helper methods
            </summary>
        </member>
        <member name="T:SubSonic.SqlGeneration.Sql2005Generator">
            <summary>
            
            </summary>
        </member>
        <member name="M:SubSonic.SqlGeneration.Sql2005Generator.#ctor(SubSonic.Query.SqlQuery)">
            <summary>
            Initializes a new instance of the <see cref="T:SubSonic.SqlGeneration.Sql2005Generator"/> class.
            </summary>
            <param name="query">The query.</param>
        </member>
        <member name="M:SubSonic.SqlGeneration.Sql2005Generator.BuildPagedSelectStatement">
            <summary>
            Builds the paged select statement.
            </summary>
            <returns></returns>
        </member>
        <member name="M:SubSonic.SqlGeneration.Sql2005Generator.BuildInsertStatement">
            <summary>
            Builds the insert statement.
            </summary>
            <returns></returns>
        </member>
        <member name="T:SubSonic.Linq.Translation.AggregateChecker">
            <summary>
            Determines if a SelectExpression contains any aggregate expressions
            </summary>
        </member>
        <member name="T:SubSonic.Extensions.Inflector">
            <summary>
            Summary for the Inflector class
            </summary>
        </member>
        <member name="M:SubSonic.Extensions.Inflector.#cctor">
            <summary>
            Initializes the <see cref="T:SubSonic.Extensions.Inflector"/> class.
            </summary>
        </member>
        <member name="M:SubSonic.Extensions.Inflector.AddIrregularRule(System.String,System.String)">
            <summary>
            Adds the irregular rule.
            </summary>
            <param name="singular">The singular.</param>
            <param name="plural">The plural.</param>
        </member>
        <member name="M:SubSonic.Extensions.Inflector.AddUnknownCountRule(System.String)">
            <summary>
            Adds the unknown count rule.
            </summary>
            <param name="word">The word.</param>
        </member>
        <member name="M:SubSonic.Extensions.Inflector.AddPluralRule(System.String,System.String)">
            <summary>
            Adds the plural rule.
            </summary>
            <param name="rule">The rule.</param>
            <param name="replacement">The replacement.</param>
        </member>
        <member name="M:SubSonic.Extensions.Inflector.AddSingularRule(System.String,System.String)">
            <summary>
            Adds the singular rule.
            </summary>
            <param name="rule">The rule.</param>
            <param name="replacement">The replacement.</param>
        </member>
        <member name="M:SubSonic.Extensions.Inflector.MakePlural(System.String)">
            <summary>
            Makes the plural.
            </summary>
            <param name="word">The word.</param>
            <returns></returns>
        </member>
        <member name="M:SubSonic.Extensions.Inflector.MakeSingular(System.String)">
            <summary>
            Makes the singular.
            </summary>
            <param name="word">The word.</param>
            <returns></returns>
        </member>
        <member name="M:SubSonic.Extensions.Inflector.ApplyRules(System.Collections.Generic.IList{SubSonic.Extensions.Inflector.InflectorRule},System.String)">
            <summary>
            Applies the rules.
            </summary>
            <param name="rules">The rules.</param>
            <param name="word">The word.</param>
            <returns></returns>
        </member>
        <member name="M:SubSonic.Extensions.Inflector.ToTitleCase(System.String)">
            <summary>
            Converts the string to title case.
            </summary>
            <param name="word">The word.</param>
            <returns></returns>
        </member>
        <member name="M:SubSonic.Extensions.Inflector.ToHumanCase(System.String)">
            <summary>
            Converts the string to human case.
            </summary>
            <param name="lowercaseAndUnderscoredWord">The lowercase and underscored word.</param>
            <returns></returns>
        </member>
        <member name="M:SubSonic.Extensions.Inflector.ToProper(System.String)">
            <summary>
            Convert string to proper case
            </summary>
            <param name="sourceString">The source string.</param>
            <returns></returns>
        </member>
        <member name="M:SubSonic.Extensions.Inflector.ToPascalCase(System.String)">
            <summary>
            Converts the string to pascal case.
            </summary>
            <param name="lowercaseAndUnderscoredWord">The lowercase and underscored word.</param>
            <returns></returns>
        </member>
        <member name="M:SubSonic.Extensions.Inflector.ToPascalCase(System.String,System.Boolean)">
            <summary>
            Converts text to pascal case...
            </summary>
            <param name="text">The text.</param>
            <param name="removeUnderscores">if set to <c>true</c> [remove underscores].</param>
            <returns></returns>
        </member>
        <member name="M:SubSonic.Extensions.Inflector.ToCamelCase(System.String)">
            <summary>
            Converts the string to camel case.
            </summary>
            <param name="lowercaseAndUnderscoredWord">The lowercase and underscored word.</param>
            <returns></returns>
        </member>
        <member name="M:SubSonic.Extensions.Inflector.AddUnderscores(System.String)">
            <summary>
            Adds the underscores.
            </summary>
            <param name="pascalCasedWord">The pascal cased word.</param>
            <returns></returns>
        </member>
        <member name="M:SubSonic.Extensions.Inflector.MakeInitialCaps(System.String)">
            <summary>
            Makes the initial caps.
            </summary>
            <param name="word">The word.</param>
            <returns></returns>
        </member>
        <member name="M:SubSonic.Extensions.Inflector.MakeInitialLowerCase(System.String)">
            <summary>
            Makes the initial lower case.
            </summary>
            <param name="word">The word.</param>
            <returns></returns>
        </member>
        <member name="M:SubSonic.Extensions.Inflector.AddOrdinalSuffix(System.String)">
            <summary>
            Adds the ordinal suffix.
            </summary>
            <param name="number">The number.</param>
            <returns></returns>
        </member>
        <member name="M:SubSonic.Extensions.Inflector.ConvertUnderscoresToDashes(System.String)">
            <summary>
            Converts the underscores to dashes.
            </summary>
            <param name="underscoredWord">The underscored word.</param>
            <returns></returns>
        </member>
        <member name="T:SubSonic.Extensions.Inflector.InflectorRule">
            <summary>
            Summary for the InflectorRule class
            </summary>
        </member>
        <member name="F:SubSonic.Extensions.Inflector.InflectorRule.regex">
            <summary>
            
            </summary>
        </member>
        <member name="F:SubSonic.Extensions.Inflector.InflectorRule.replacement">
            <summary>
            
            </summary>
        </member>
        <member name="M:SubSonic.Extensions.Inflector.InflectorRule.#ctor(System.String,System.String)">
            <summary>
            Initializes a new instance of the <see cref="T:SubSonic.Extensions.Inflector.InflectorRule"/> class.
            </summary>
            <param name="regexPattern">The regex pattern.</param>
            <param name="replacementText">The replacement text.</param>
        </member>
        <member name="M:SubSonic.Extensions.Inflector.InflectorRule.Apply(System.String)">
            <summary>
            Applies the specified word.
            </summary>
            <param name="word">The word.</param>
            <returns></returns>
        </member>
        <member name="T:SubSonic.Extensions.Dates">
            <summary>
            Summary for the Dates class
            </summary>
        </member>
        <member name="M:SubSonic.Extensions.Dates.DaysAgo(System.Int32)">
            <summary>
            Returns a date in the past by days.
            </summary>
            <param name="days">The days.</param>
            <returns></returns>
        </member>
        <member name="M:SubSonic.Extensions.Dates.DaysFromNow(System.Int32)">
            <summary>
             Returns a date in the future by days.
            </summary>
            <param name="days">The days.</param>
            <returns></returns>
        </member>
        <member name="M:SubSonic.Extensions.Dates.HoursAgo(System.Int32)">
            <summary>
            Returns a date in the past by hours.
            </summary>
            <param name="hours">The hours.</param>
            <returns></returns>
        </member>
        <member name="M:SubSonic.Extensions.Dates.HoursFromNow(System.Int32)">
            <summary>
            Returns a date in the future by hours.
            </summary>
            <param name="hours">The hours.</param>
            <returns></returns>
        </member>
        <member name="M:SubSonic.Extensions.Dates.MinutesAgo(System.Int32)">
            <summary>
            Returns a date in the past by minutes
            </summary>
            <param name="minutes">The minutes.</param>
            <returns></returns>
        </member>
        <member name="M:SubSonic.Extensions.Dates.MinutesFromNow(System.Int32)">
            <summary>
            Returns a date in the future by minutes.
            </summary>
            <param name="minutes">The minutes.</param>
            <returns></returns>
        </member>
        <member name="M:SubSonic.Extensions.Dates.SecondsAgo(System.Int32)">
            <summary>
            Gets a date in the past according to seconds
            </summary>
            <param name="seconds">The seconds.</param>
            <returns></returns>
        </member>
        <member name="M:SubSonic.Extensions.Dates.SecondsFromNow(System.Int32)">
            <summary>
            Gets a date in the future by seconds.
            </summary>
            <param name="seconds">The seconds.</param>
            <returns></returns>
        </member>
        <member name="M:SubSonic.Extensions.Dates.Diff(System.DateTime,System.DateTime)">
            <summary>
            Diffs the specified date.
            </summary>
            <param name="dateOne">The date one.</param>
            <param name="dateTwo">The date two.</param>
            <returns></returns>
        </member>
        <member name="M:SubSonic.Extensions.Dates.DiffDays(System.String,System.String)">
            <summary>
            Returns a double indicating the number of days between two dates (past is negative)
            </summary>
            <param name="dateOne">The date one.</param>
            <param name="dateTwo">The date two.</param>
            <returns></returns>
        </member>
        <member name="M:SubSonic.Extensions.Dates.DiffDays(System.DateTime,System.DateTime)">
            <summary>
            Returns a double indicating the number of days between two dates (past is negative)
            </summary>
            <param name="dateOne">The date one.</param>
            <param name="dateTwo">The date two.</param>
            <returns></returns>
        </member>
        <member name="M:SubSonic.Extensions.Dates.DiffHours(System.String,System.String)">
            <summary>
            Returns a double indicating the number of days between two dates (past is negative)
            </summary>
            <param name="dateOne">The date one.</param>
            <param name="dateTwo">The date two.</param>
            <returns></returns>
        </member>
        <member name="M:SubSonic.Extensions.Dates.DiffHours(System.DateTime,System.DateTime)">
            <summary>
            Returns a double indicating the number of days between two dates (past is negative)
            </summary>
            <param name="dateOne">The date one.</param>
            <param name="dateTwo">The date two.</param>
            <returns></returns>
        </member>
        <member name="M:SubSonic.Extensions.Dates.DiffMinutes(System.String,System.String)">
            <summary>
            Returns a double indicating the number of days between two dates (past is negative)
            </summary>
            <param name="dateOne">The date one.</param>
            <param name="dateTwo">The date two.</param>
            <returns></returns>
        </member>
        <member name="M:SubSonic.Extensions.Dates.DiffMinutes(System.DateTime,System.DateTime)">
            <summary>
            Returns a double indicating the number of days between two dates (past is negative)
            </summary>
            <param name="dateOne">The date one.</param>
            <param name="dateTwo">The date two.</param>
            <returns></returns>
        </member>
        <member name="M:SubSonic.Extensions.Dates.ReadableDiff(System.DateTime,System.DateTime)">
            <summary>
            Displays the difference in time between the two dates. Return example is "12 years 4 months 24 days 8 hours 33 minutes 5 seconds"
            </summary>
            <param name="startTime">The start time.</param>
            <param name="endTime">The end time.</param>
            <returns></returns>
        </member>
        <member name="M:SubSonic.Extensions.Dates.CountWeekdays(System.DateTime,System.DateTime)">
            <summary>
            Counts the number of weekdays between two dates.
            </summary>
            <param name="startTime">The start time.</param>
            <param name="endTime">The end time.</param>
            <returns></returns>
        </member>
        <member name="M:SubSonic.Extensions.Dates.CountWeekends(System.DateTime,System.DateTime)">
            <summary>
            Counts the number of weekends between two dates.
            </summary>
            <param name="startTime">The start time.</param>
            <param name="endTime">The end time.</param>
            <returns></returns>
        </member>
        <member name="M:SubSonic.Extensions.Dates.IsDate(System.Object)">
            <summary>
            Verifies if the object is a date
            </summary>
            <param name="dt">The dt.</param>
            <returns>
            	<c>true</c> if the specified dt is date; otherwise, <c>false</c>.
            </returns>
        </member>
        <member name="M:SubSonic.Extensions.Dates.IsWeekDay(System.DateTime)">
            <summary>
            Checks to see if the date is a week day (Mon - Fri)
            </summary>
            <param name="dt">The dt.</param>
            <returns>
            	<c>true</c> if [is week day] [the specified dt]; otherwise, <c>false</c>.
            </returns>
        </member>
        <member name="M:SubSonic.Extensions.Dates.IsWeekEnd(System.DateTime)">
            <summary>
            Checks to see if the date is Saturday or Sunday
            </summary>
            <param name="dt">The dt.</param>
            <returns>
            	<c>true</c> if [is week end] [the specified dt]; otherwise, <c>false</c>.
            </returns>
        </member>
        <member name="M:SubSonic.Extensions.Dates.TimeDiff(System.DateTime,System.DateTime)">
            <summary>
            Displays the difference in time between the two dates. Return example is "12 years 4 months 24 days 8 hours 33 minutes 5 seconds"
            </summary>
            <param name="startTime">The start time.</param>
            <param name="endTime">The end time.</param>
            <returns></returns>
        </member>
        <member name="M:SubSonic.Extensions.Dates.GetFormattedMonthAndDay(System.DateTime)">
            <summary>
            Given a datetime object, returns the formatted month and day, i.e. "April 15th"
            </summary>
            <param name="date">The date to extract the string from</param>
            <returns></returns>
        </member>
        <member name="M:SubSonic.Extensions.Dates.GetDateDayWithSuffix(System.DateTime)">
            <summary>
            Given a datetime object, returns the formatted day, "15th"
            </summary>
            <param name="date">The date to extract the string from</param>
            <returns></returns>
        </member>
        <member name="M:SubSonic.Extensions.Dates.FormatString(System.String,System.String,System.Int32)">
            <summary>
            Remove leading strings with zeros and adjust for singular/plural
            </summary>
            <param name="str">The STR.</param>
            <param name="previousStr">The previous STR.</param>
            <param name="t">The t.</param>
            <returns></returns>
        </member>
        <member name="T:SubSonic.Query.Join">
            <summary>
            
            </summary>
        </member>
        <member name="M:SubSonic.Query.Join.#ctor(SubSonic.Schema.IColumn,SubSonic.Schema.IColumn,SubSonic.Query.Join.JoinType)">
            <summary>
            Initializes a new instance of the <see cref="T:SubSonic.Query.Join"/> class.
            </summary>
            <param name="from">From.</param>
            <param name="to">To.</param>
            <param name="joinType">Type of the join.</param>
        </member>
        <member name="M:SubSonic.Query.Join.GetJoinTypeValue(SubSonic.SqlGeneration.ISqlGenerator,SubSonic.Query.Join.JoinType)">
            <summary>
            Gets the join type value.
            </summary>
            <param name="j">The j.</param>
            <returns></returns>
        </member>
        <member name="P:SubSonic.Query.Join.Type">
            <summary>
            Gets or sets the type.
            </summary>
            <value>The type.</value>
        </member>
        <member name="P:SubSonic.Query.Join.FromColumn">
            <summary>
            Gets or sets from column.
            </summary>
            <value>From column.</value>
        </member>
        <member name="P:SubSonic.Query.Join.ToColumn">
            <summary>
            Gets or sets to column.
            </summary>
            <value>To column.</value>
        </member>
        <member name="T:SubSonic.Query.Join.JoinType">
            <summary>
            
            </summary>
        </member>
        <member name="F:SubSonic.Query.Join.JoinType.Inner">
            <summary>
            
            </summary>
        </member>
        <member name="F:SubSonic.Query.Join.JoinType.Outer">
            <summary>
            
            </summary>
        </member>
        <member name="F:SubSonic.Query.Join.JoinType.LeftInner">
            <summary>
            
            </summary>
        </member>
        <member name="F:SubSonic.Query.Join.JoinType.LeftOuter">
            <summary>
            
            </summary>
        </member>
        <member name="F:SubSonic.Query.Join.JoinType.RightInner">
            <summary>
            
            </summary>
        </member>
        <member name="F:SubSonic.Query.Join.JoinType.RightOuter">
            <summary>
            
            </summary>
        </member>
        <member name="F:SubSonic.Query.Join.JoinType.Cross">
            <summary>
            
            </summary>
        </member>
        <member name="F:SubSonic.Query.Join.JoinType.NotEqual">
            <summary>
            
            </summary>
        </member>
        <member name="T:SubSonic.Linq.Translation.SQLite.SqliteFormatter">
            <summary>
            Formats a query expression into TSQL language syntax
            </summary>
        </member>
        <member name="T:SubSonic.Linq.Structure.TSqlFormatter">
            <summary>
            Formats a query expression into TSQL language syntax
            </summary>
        </member>
        <member name="T:SubSonic.Linq.Translation.QueryDuplicator">
            <summary>
            Duplicate the query expression by making a copy with new table aliases
            </summary>
        </member>
        <member name="T:SubSonic.Linq.Translation.MySql.MySqlFormatter">
            <summary>
            Formats a query expression into TSQL language syntax
            </summary>
        </member>
        <member name="M:SubSonic.Extensions.Strings.#cctor">
            <summary>
            Initializes the <see cref="T:SubSonic.Extensions.Strings"/> class.
            </summary>
        </member>
        <member name="M:SubSonic.Extensions.Strings.Chop(System.String,System.Int32)">
            <summary>
            Strips the last specified chars from a string.
            </summary>
            <param name="sourceString">The source string.</param>
            <param name="removeFromEnd">The remove from end.</param>
            <returns></returns>
        </member>
        <member name="M:SubSonic.Extensions.Strings.Chop(System.String,System.String)">
            <summary>
            Strips the last specified chars from a string.
            </summary>
            <param name="sourceString">The source string.</param>
            <param name="backDownTo">The back down to.</param>
            <returns></returns>
        </member>
        <member name="M:SubSonic.Extensions.Strings.PluralToSingular(System.String)">
            <summary>
            Plurals to singular.
            </summary>
            <param name="sourceString">The source string.</param>
            <returns></returns>
        </member>
        <member name="M:SubSonic.Extensions.Strings.SingularToPlural(System.String)">
            <summary>
            Singulars to plural.
            </summary>
            <param name="sourceString">The source string.</param>
            <returns></returns>
        </member>
        <member name="M:SubSonic.Extensions.Strings.Pluralize(System.Int32,System.String)">
            <summary>
            Make plural when count is not one
            </summary>
            <param name="number">The number of things</param>
            <param name="sourceString">The source string.</param>
            <returns></returns>
        </member>
        <member name="M:SubSonic.Extensions.Strings.Clip(System.String,System.Int32)">
            <summary>
            Removes the specified chars from the beginning of a string.
            </summary>
            <param name="sourceString">The source string.</param>
            <param name="removeFromBeginning">The remove from beginning.</param>
            <returns></returns>
        </member>
        <member name="M:SubSonic.Extensions.Strings.Clip(System.String,System.String)">
            <summary>
            Removes chars from the beginning of a string, up to the specified string
            </summary>
            <param name="sourceString">The source string.</param>
            <param name="removeUpTo">The remove up to.</param>
            <returns></returns>
        </member>
        <member name="M:SubSonic.Extensions.Strings.Chop(System.String)">
            <summary>
            Strips the last char from a a string.
            </summary>
            <param name="sourceString">The source string.</param>
            <returns></returns>
        </member>
        <member name="M:SubSonic.Extensions.Strings.Clip(System.String)">
            <summary>
            Strips the last char from a a string.
            </summary>
            <param name="sourceString">The source string.</param>
            <returns></returns>
        </member>
        <member name="M:SubSonic.Extensions.Strings.FastReplace(System.String,System.String,System.String)">
            <summary>
            Fasts the replace.
            </summary>
            <param name="original">The original.</param>
            <param name="pattern">The pattern.</param>
            <param name="replacement">The replacement.</param>
            <returns></returns>
        </member>
        <member name="M:SubSonic.Extensions.Strings.FastReplace(System.String,System.String,System.String,System.StringComparison)">
            <summary>
            Fasts the replace.
            </summary>
            <param name="original">The original.</param>
            <param name="pattern">The pattern.</param>
            <param name="replacement">The replacement.</param>
            <param name="comparisonType">Type of the comparison.</param>
            <returns></returns>
        </member>
        <member name="M:SubSonic.Extensions.Strings.Crop(System.String,System.String,System.String)">
            <summary>
            Returns text that is located between the startText and endText tags.
            </summary>
            <param name="sourceString">The source string.</param>
            <param name="startText">The text from which to start the crop</param>
            <param name="endText">The endpoint of the crop</param>
            <returns></returns>
        </member>
        <member name="M:SubSonic.Extensions.Strings.Squeeze(System.String)">
            <summary>
            Removes excess white space in a string.
            </summary>
            <param name="sourceString">The source string.</param>
            <returns></returns>
        </member>
        <member name="M:SubSonic.Extensions.Strings.ToAlphaNumericOnly(System.String)">
            <summary>
            Removes all non-alpha numeric characters in a string
            </summary>
            <param name="sourceString">The source string.</param>
            <returns></returns>
        </member>
        <member name="M:SubSonic.Extensions.Strings.ToWords(System.String)">
            <summary>
            Creates a string array based on the words in a sentence
            </summary>
            <param name="sourceString">The source string.</param>
            <returns></returns>
        </member>
        <member name="M:SubSonic.Extensions.Strings.StripHTML(System.String)">
            <summary>
            Strips all HTML tags from a string
            </summary>
            <param name="htmlString">The HTML string.</param>
            <returns></returns>
        </member>
        <member name="M:SubSonic.Extensions.Strings.StripHTML(System.String,System.String)">
            <summary>
            Strips all HTML tags from a string and replaces the tags with the specified replacement
            </summary>
            <param name="htmlString">The HTML string.</param>
            <param name="htmlPlaceHolder">The HTML place holder.</param>
            <returns></returns>
        </member>
        <member name="M:SubSonic.Extensions.Strings.ToDelimitedList(System.Collections.Generic.IEnumerable{System.String})">
            <summary>
            Converts a generic List collection to a single comma-delimitted string.
            </summary>
            <param name="list">The list.</param>
            <returns></returns>
        </member>
        <member name="M:SubSonic.Extensions.Strings.ToDelimitedList(System.Collections.Generic.IEnumerable{System.String},System.String)">
            <summary>
            Converts a generic List collection to a single string using the specified delimitter.
            </summary>
            <param name="list">The list.</param>
            <param name="delimiter">The delimiter.</param>
            <returns></returns>
        </member>
        <member name="M:SubSonic.Extensions.Strings.Strip(System.String,System.String)">
            <summary>
            Strips the specified input.
            </summary>
            <param name="sourceString">The source string.</param>
            <param name="stripValue">The strip value.</param>
            <returns></returns>
        </member>
        <member name="M:SubSonic.Extensions.Strings.AsciiToUnicode(System.Int32)">
            <summary>
            Converts ASCII encoding to Unicode
            </summary>
            <param name="asciiCode">The ASCII code.</param>
            <returns></returns>
        </member>
        <member name="M:SubSonic.Extensions.Strings.TextToEntity(System.String)">
            <summary>
            Converts Text to HTML-encoded string
            </summary>
            <param name="textString">The text string.</param>
            <returns></returns>
        </member>
        <member name="M:SubSonic.Extensions.Strings.EntityToText(System.String)">
            <summary>
            Converts HTML-encoded bits to Text
            </summary>
            <param name="entityText">The entity text.</param>
            <returns></returns>
        </member>
        <member name="M:SubSonic.Extensions.Strings.ToFormattedString(System.String,System.Object[])">
            <summary>
            Formats the args using String.Format with the target string as a format string.
            </summary>
            <param name="fmt">The format string passed to String.Format</param>
            <param name="args">The args passed to String.Format</param>
            <returns></returns>
        </member>
        <member name="M:SubSonic.Extensions.Strings.ToEnum``1(System.String)">
            <summary>
            Strings to enum.
            </summary>
            <typeparam name="T"></typeparam>
            <param name="Value">The value.</param>
            <returns></returns>
        </member>
        <member name="M:SubSonic.Extensions.Strings.FillEntities">
            <summary>
            Fills the entities.
            </summary>
        </member>
        <member name="M:SubSonic.Extensions.Strings.USStateNameToAbbrev(System.String)">
            <summary>
            Converts US State Name to it's two-character abbreviation. Returns null if the state name was not found.
            </summary>
            <param name="stateName">US State Name (ie Texas)</param>
            <returns></returns>
        </member>
        <member name="M:SubSonic.Extensions.Strings.USStateAbbrevToName(System.String)">
            <summary>
            Converts a two-character US State Abbreviation to it's official Name Returns null if the abbreviation was not found.
            </summary>
            <param name="stateAbbrev">US State Name (ie Texas)</param>
            <returns></returns>
        </member>
        <member name="M:SubSonic.Extensions.Strings.FillUSStates">
            <summary>
            Fills the US States.
            </summary>
        </member>
        <member name="T:SubSonic.Extensions.IO">
            <summary>
            Summary for the Files class
            </summary>
        </member>
        <member name="M:SubSonic.Extensions.IO.GetFileText(System.String)">
            <summary>
            Read a text file and obtain it's contents.
            </summary>
            <param name="absolutePath">The complete file path to write to.</param>
            <returns>String containing the content of the file.</returns>
        </member>
        <member name="M:SubSonic.Extensions.IO.CreateToFile(System.String,System.String)">
            <summary>
            Creates or opens a file for writing and writes text to it.
            </summary>
            <param name="absolutePath">The complete file path to write to.</param>
            <param name="fileText">A String containing text to be written to the file.</param>
        </member>
        <member name="M:SubSonic.Extensions.IO.UpdateFileText(System.String,System.String,System.String)">
            <summary>
            Update text within a file by replacing a substring within the file.
            </summary>
            <param name="absolutePath">The complete file path to write to.</param>
            <param name="lookFor">A String to be replaced.</param>
            <param name="replaceWith">A String to replace all occurrences of lookFor.</param>
        </member>
        <member name="M:SubSonic.Extensions.IO.WriteToFile(System.String,System.String)">
            <summary>
            Writes out a string to a file.
            </summary>
            <param name="absolutePath">The complete file path to write to.</param>
            <param name="fileText">A String containing text to be written to the file.</param>
        </member>
        <member name="M:SubSonic.Extensions.IO.ReadWebPage(System.String)">
            <summary>
            Fetches a web page
            </summary>
            <param name="url">The URL.</param>
            <returns></returns>
        </member>
        <member name="M:SubSonic.Extensions.Database.GetSqlDBType(System.Data.DbType)">
            <summary>
            Returns the SqlDbType for a give DbType
            </summary>
            <returns></returns>
        </member>
        <member name="M:SubSonic.Extensions.Database.ToConstraintList(System.Object)">
            <summary>
            Takes the properties of an object and turns them into SubSonic.Query.Constraint
            </summary>
            <param name="value"></param>
            <returns></returns>
        </member>
        <member name="M:SubSonic.Extensions.Database.Load``1(System.Data.IDataReader,``0,System.Collections.Generic.List{System.String})">
            <summary>
            Coerces an IDataReader to try and load an object using name/property matching
            </summary>
        </member>
        <member name="M:SubSonic.Extensions.Database.LoadValueType``1(System.Data.IDataReader,``0@)">
            <summary>
            Loads a single primitive value type
            </summary>
            <typeparam name="T"></typeparam>
        </member>
        <member name="M:SubSonic.Extensions.Database.ToEnumerableValueType``1(System.Data.IDataReader)">
            <summary>
            Toes the type of the enumerable value.
            </summary>
            <typeparam name="T"></typeparam>
            <param name="rdr">The IDataReader to read from.</param>
            <returns></returns>
        </member>
        <member name="M:SubSonic.Extensions.Database.IsCoreSystemType(System.Type)">
            <summary>
            Determines whether [is core system type] [the specified type].
            </summary>
            <param name="type">The type.</param>
            <returns>
            	<c>true</c> if [is core system type] [the specified type]; otherwise, <c>false</c>.
            </returns>
        </member>
        <member name="M:SubSonic.Extensions.Database.ToEnumerable``1(System.Data.IDataReader,System.Collections.Generic.List{System.String})">
            <summary>
            Coerces an IDataReader to load an enumerable of T
            </summary>
            <typeparam name="T"></typeparam>
            <param name="rdr"></param>
        </member>
        <member name="M:SubSonic.Extensions.Database.ToList``1(System.Data.IDataReader)">
            <summary>
            Creates a typed list from an IDataReader
            </summary>
        </member>
        <member name="M:SubSonic.Extensions.Database.ToUpdateQuery``1(``0,SubSonic.DataProviders.IDataProvider)">
            <summary>
             Builds a SubSonic UPDATE query from the passed-in object
            </summary>
        </member>
        <member name="M:SubSonic.Extensions.Database.ToInsertQuery``1(``0,SubSonic.DataProviders.IDataProvider)">
            <summary>
             Builds a SubSonic INSERT query from the passed-in object
            </summary>
        </member>
        <member name="M:SubSonic.Extensions.Database.ToDeleteQuery``1(``0,SubSonic.DataProviders.IDataProvider)">
            <summary>
             Builds a SubSonic DELETE query from the passed-in object
            </summary>
        </member>
        <member name="T:SubSonic.Linq.Structure.ExpressionWriter">
            <summary>
            Writes out an expression tree in a C#-ish syntax
            </summary>
        </member>
        <member name="T:SubSonic.Linq.Translation.RelationshipBinder">
            <summary>
            Translates accesses to relationship members into projections or joins
            </summary>
        </member>
        <member name="T:SubSonic.Linq.Translation.QueryBinder">
            <summary>
            Converts LINQ query operators to into custom DbExpression's
            </summary>
        </member>
        <member name="T:SubSonic.Linq.Translation.ColumnMapper">
            <summary>
            Rewrite all column references to one or more aliases to a new single alias
            </summary>
        </member>
        <member name="T:SubSonic.Linq.Structure.DbExpressionReplacer">
            <summary>
            Replaces references to one specific instance of an expression node with another node.
            Supports DbExpression nodes
            </summary>
        </member>
        <member name="T:SubSonic.Linq.Structure.DbExpressionComparer">
            <summary>
            Determines if two expressions are equivalent. Supports DbExpression nodes.
            </summary>
        </member>
        <member name="T:SubSonic.Extensions.Validation">
            <summary>
            Summary for the Validation class
            </summary>
        </member>
        <member name="M:SubSonic.Extensions.Validation.IsAlpha(System.String)">
            <summary>
            Determines whether the specified eval string contains only alpha characters.
            </summary>
            <param name="evalString">The eval string.</param>
            <returns>
            	<c>true</c> if the specified eval string is alpha; otherwise, <c>false</c>.
            </returns>
        </member>
        <member name="M:SubSonic.Extensions.Validation.IsAlphaNumeric(System.String)">
            <summary>
            Determines whether the specified eval string contains only alphanumeric characters
            </summary>
            <param name="evalString">The eval string.</param>
            <returns>
            	<c>true</c> if the string is alphanumeric; otherwise, <c>false</c>.
            </returns>
        </member>
        <member name="M:SubSonic.Extensions.Validation.IsAlphaNumeric(System.String,System.Boolean)">
            <summary>
            Determines whether the specified eval string contains only alphanumeric characters
            </summary>
            <param name="evalString">The eval string.</param>
            <param name="allowSpaces">if set to <c>true</c> [allow spaces].</param>
            <returns>
            	<c>true</c> if the string is alphanumeric; otherwise, <c>false</c>.
            </returns>
        </member>
        <member name="M:SubSonic.Extensions.Validation.IsNumeric(System.String)">
            <summary>
            Determines whether the specified eval string contains only numeric characters
            </summary>
            <param name="evalString">The eval string.</param>
            <returns>
            	<c>true</c> if the string is numeric; otherwise, <c>false</c>.
            </returns>
        </member>
        <member name="M:SubSonic.Extensions.Validation.IsEmail(System.String)">
            <summary>
            Determines whether the specified email address string is valid based on regular expression evaluation.
            </summary>
            <param name="emailAddressString">The email address string.</param>
            <returns>
            	<c>true</c> if the specified email address is valid; otherwise, <c>false</c>.
            </returns>
        </member>
        <member name="M:SubSonic.Extensions.Validation.IsLowerCase(System.String)">
            <summary>
            Determines whether the specified string is lower case.
            </summary>
            <param name="inputString">The input string.</param>
            <returns>
            	<c>true</c> if the specified string is lower case; otherwise, <c>false</c>.
            </returns>
        </member>
        <member name="M:SubSonic.Extensions.Validation.IsUpperCase(System.String)">
            <summary>
            Determines whether the specified string is upper case.
            </summary>
            <param name="inputString">The input string.</param>
            <returns>
            	<c>true</c> if the specified string is upper case; otherwise, <c>false</c>.
            </returns>
        </member>
        <member name="M:SubSonic.Extensions.Validation.IsGuid(System.String)">
            <summary>
            Determines whether the specified string is a valid GUID.
            </summary>
            <param name="guid">The GUID.</param>
            <returns>
            	<c>true</c> if the specified string is a valid GUID; otherwise, <c>false</c>.
            </returns>
        </member>
        <member name="M:SubSonic.Extensions.Validation.IsZIPCodeAny(System.String)">
            <summary>
            Determines whether the specified string is a valid US Zip Code, using either 5 or 5+4 format.
            </summary>
            <param name="zipCode">The zip code.</param>
            <returns>
            	<c>true</c> if it is a valid zip code; otherwise, <c>false</c>.
            </returns>
        </member>
        <member name="M:SubSonic.Extensions.Validation.IsZIPCodeFive(System.String)">
            <summary>
            Determines whether the specified string is a valid US Zip Code, using the 5 digit format.
            </summary>
            <param name="zipCode">The zip code.</param>
            <returns>
            	<c>true</c> if it is a valid zip code; otherwise, <c>false</c>.
            </returns>
        </member>
        <member name="M:SubSonic.Extensions.Validation.IsZIPCodeFivePlusFour(System.String)">
            <summary>
            Determines whether the specified string is a valid US Zip Code, using the 5+4 format.
            </summary>
            <param name="zipCode">The zip code.</param>
            <returns>
            	<c>true</c> if it is a valid zip code; otherwise, <c>false</c>.
            </returns>
        </member>
        <member name="M:SubSonic.Extensions.Validation.IsSocialSecurityNumber(System.String)">
            <summary>
            Determines whether the specified string is a valid Social Security number. Dashes are optional.
            </summary>
            <param name="socialSecurityNumber">The Social Security Number</param>
            <returns>
            	<c>true</c> if it is a valid Social Security number; otherwise, <c>false</c>.
            </returns>
        </member>
        <member name="M:SubSonic.Extensions.Validation.IsIPAddress(System.String)">
            <summary>
            Determines whether the specified string is a valid IP address.
            </summary>
            <param name="ipAddress">The ip address.</param>
            <returns>
            	<c>true</c> if valid; otherwise, <c>false</c>.
            </returns>
        </member>
        <member name="M:SubSonic.Extensions.Validation.IsUSTelephoneNumber(System.String)">
            <summary>
            Determines whether the specified string is a valid US phone number using the referenced regex string.
            </summary>
            <param name="telephoneNumber">The telephone number.</param>
            <returns>
            	<c>true</c> if valid; otherwise, <c>false</c>.
            </returns>
        </member>
        <member name="M:SubSonic.Extensions.Validation.IsUSCurrency(System.String)">
            <summary>
            Determines whether the specified string is a valid currency string using the referenced regex string.
            </summary>
            <param name="currency">The currency string.</param>
            <returns>
            	<c>true</c> if valid; otherwise, <c>false</c>.
            </returns>
        </member>
        <member name="M:SubSonic.Extensions.Validation.IsURL(System.String)">
            <summary>
            Determines whether the specified string is a valid URL string using the referenced regex string.
            </summary>
            <param name="url">The URL string.</param>
            <returns>
            	<c>true</c> if valid; otherwise, <c>false</c>.
            </returns>
        </member>
        <member name="M:SubSonic.Extensions.Validation.IsStrongPassword(System.String)">
            <summary>
            Determines whether the specified string is consider a strong password based on the supplied string.
            </summary>
            <param name="password">The password.</param>
            <returns>
            	<c>true</c> if strong; otherwise, <c>false</c>.
            </returns>
        </member>
        <member name="M:SubSonic.Extensions.Validation.IsCreditCardAny(System.String)">
            <summary>
            Determines whether the specified string is a valid credit, based on matching any one of the eight credit card strings
            </summary>
            <param name="creditCard">The credit card.</param>
            <returns>
            	<c>true</c> if valid; otherwise, <c>false</c>.
            </returns>
        </member>
        <member name="M:SubSonic.Extensions.Validation.IsCreditCardBigFour(System.String)">
            <summary>
            Determines whether the specified string is an American Express, Discover, MasterCard, or Visa
            </summary>
            <param name="creditCard">The credit card.</param>
            <returns>
            	<c>true</c> if valid; otherwise, <c>false</c>.
            </returns>
        </member>
        <member name="M:SubSonic.Extensions.Validation.IsCreditCardAmericanExpress(System.String)">
            <summary>
            Determines whether the specified string is an American Express card
            </summary>
            <param name="creditCard">The credit card.</param>
            <returns>
            	<c>true</c> if valid; otherwise, <c>false</c>.
            </returns>
        </member>
        <member name="M:SubSonic.Extensions.Validation.IsCreditCardCarteBlanche(System.String)">
            <summary>
            Determines whether the specified string is an Carte Blanche card
            </summary>
            <param name="creditCard">The credit card.</param>
            <returns>
            	<c>true</c> if valid; otherwise, <c>false</c>.
            </returns>
        </member>
        <member name="M:SubSonic.Extensions.Validation.IsCreditCardDinersClub(System.String)">
            <summary>
            Determines whether the specified string is an Diner's Club card
            </summary>
            <param name="creditCard">The credit card.</param>
            <returns>
            	<c>true</c> if valid; otherwise, <c>false</c>.
            </returns>
        </member>
        <member name="M:SubSonic.Extensions.Validation.IsCreditCardDiscover(System.String)">
            <summary>
            Determines whether the specified string is a Discover card
            </summary>
            <param name="creditCard">The credit card.</param>
            <returns>
            	<c>true</c> if valid; otherwise, <c>false</c>.
            </returns>
        </member>
        <member name="M:SubSonic.Extensions.Validation.IsCreditCardEnRoute(System.String)">
            <summary>
            Determines whether the specified string is an En Route card
            </summary>
            <param name="creditCard">The credit card.</param>
            <returns>
            	<c>true</c> if valid; otherwise, <c>false</c>.
            </returns>
        </member>
        <member name="M:SubSonic.Extensions.Validation.IsCreditCardJCB(System.String)">
            <summary>
            Determines whether the specified string is an JCB card
            </summary>
            <param name="creditCard">The credit card.</param>
            <returns>
            	<c>true</c> if valid; otherwise, <c>false</c>.
            </returns>
        </member>
        <member name="M:SubSonic.Extensions.Validation.IsCreditCardMasterCard(System.String)">
            <summary>
            Determines whether the specified string is a Master Card credit card
            </summary>
            <param name="creditCard">The credit card.</param>
            <returns>
            	<c>true</c> if valid; otherwise, <c>false</c>.
            </returns>
        </member>
        <member name="M:SubSonic.Extensions.Validation.IsCreditCardVisa(System.String)">
            <summary>
            Determines whether the specified string is Visa card.
            </summary>
            <param name="creditCard">The credit card.</param>
            <returns>
            	<c>true</c> if valid; otherwise, <c>false</c>.
            </returns>
        </member>
        <member name="M:SubSonic.Extensions.Validation.CleanCreditCardNumber(System.String)">
            <summary>
            Cleans the credit card number, returning just the numeric values.
            </summary>
            <param name="creditCard">The credit card.</param>
            <returns></returns>
        </member>
        <member name="M:SubSonic.Extensions.Validation.CreditPassesFormatCheck(System.String)">
            <summary>
            Determines whether the credit card number, once cleaned, passes the Luhn algorith.
            See: http://en.wikipedia.org/wiki/Luhn_algorithm
            </summary>
            <param name="creditCardNumber">The credit card number.</param>
            <returns></returns>
        </member>
        <member name="M:SubSonic.Extensions.Validation.IsValidLuhn(System.Int32[])">
            <summary>
            Determines whether the specified int array passes the Luhn algorith
            </summary>
            <param name="digits">The int array to evaluate</param>
            <returns>
            	<c>true</c> if it validates; otherwise, <c>false</c>.
            </returns>
        </member>
        <member name="M:SubSonic.Extensions.Validation.IsStringNumeric(System.String)">
            <summary>
            Determine whether the passed string is numeric, by attempting to parse it to a double
            </summary>
            <param name="str">The string to evaluated for numeric conversion</param>
            <returns>
            	<c>true</c> if the string can be converted to a number; otherwise, <c>false</c>.
            </returns>
        </member>
        <member name="T:SubSonic.Linq.Translation.SQLite.SqliteLanguage">
            <summary>
            TSQL specific QueryLanguage
            </summary>
        </member>
        <member name="T:SubSonic.Linq.Translation.RedundantJoinRemover">
            <summary>
            Removes joins expressions that are identical to joins that already exist
            </summary>
        </member>
        <member name="T:SubSonic.Linq.Translation.MySql.MySqlLanguage">
            <summary>
            TSQL specific QueryLanguage
            </summary>
        </member>
        <member name="T:SubSonic.Linq.Structure.DbExpressionType">
            <summary>
            Extended node types for custom expressions
            </summary>
        </member>
        <member name="T:SubSonic.Linq.Structure.TableExpression">
            <summary>
            A custom expression node that represents a table reference in a SQL query
            </summary>
        </member>
        <member name="T:SubSonic.Linq.Structure.ColumnExpression">
            <summary>
            A custom expression node that represents a reference to a column in a SQL query
            </summary>
        </member>
        <member name="T:SubSonic.Linq.Structure.ColumnDeclaration">
            <summary>
            A declaration of a column in a SQL SELECT expression
            </summary>
        </member>
        <member name="T:SubSonic.Linq.Structure.OrderType">
            <summary>
            An SQL OrderBy order type 
            </summary>
        </member>
        <member name="T:SubSonic.Linq.Structure.OrderExpression">
            <summary>
            A pairing of an expression and an order type for use in a SQL Order By clause
            </summary>
        </member>
        <member name="T:SubSonic.Linq.Structure.SelectExpression">
            <summary>
            A custom expression node used to represent a SQL SELECT expression
            </summary>
        </member>
        <member name="T:SubSonic.Linq.Structure.JoinType">
            <summary>
            A kind of SQL join
            </summary>
        </member>
        <member name="T:SubSonic.Linq.Structure.JoinExpression">
            <summary>
            A custom expression node representing a SQL join clause
            </summary>
        </member>
        <member name="T:SubSonic.Linq.Structure.IsNullExpression">
            <summary>
            Allows is-null tests against value-types like int and float
            </summary>
        </member>
        <member name="T:SubSonic.Linq.Structure.ProjectionExpression">
            <summary>
            A custom expression representing the construction of one or more result objects from a 
            SQL select expression
            </summary>
        </member>
        <!-- Badly formed XML comment ignored for member "M:SubSonic.Extensions.QueryVisitor.VisitMethodCall(System.Linq.Expressions.MethodCallExpression)" -->
        <member name="M:SubSonic.DataProviders.DbDataProvider.InitializeSharedConnection">
            <summary>
            Initializes the shared connection.
            </summary>
            <returns></returns>
        </member>
        <member name="M:SubSonic.DataProviders.DbDataProvider.InitializeSharedConnection(System.String)">
            <summary>
            Initializes the shared connection.
            </summary>
            <param name="sharedConnectionString">The shared connection string.</param>
            <returns></returns>
        </member>
        <member name="M:SubSonic.DataProviders.DbDataProvider.ResetSharedConnection">
            <summary>
            Resets the shared connection.
            </summary>
        </member>
        <member name="M:SubSonic.DataProviders.DbDataProvider.AddParams(System.Data.Common.DbCommand,SubSonic.Query.QueryCommand)">
            <summary>
            Adds the params.
            </summary>
            <param name="cmd">The CMD.</param>
            <param name="qry">The qry.</param>
        </member>
        <member name="P:SubSonic.DataProviders.DbDataProvider.CurrentConnectionStringIsDefault">
            <summary>
            Gets a value indicating whether [current connection string is default].
            </summary>
            <value>
            	<c>true</c> if [current connection string is default]; otherwise, <c>false</c>.
            </value>
        </member>
        <member name="P:SubSonic.DataProviders.DbDataProvider.CurrentSharedConnection">
            <summary>
            Gets or sets the current shared connection.
            </summary>
            <value>The current shared connection.</value>
        </member>
        <member name="T:SubSonic.Repository.SubSonicRepository`1">
            <summary>
            A Repository class which wraps the a Database by type
            </summary>
        </member>
        <member name="M:SubSonic.Repository.SubSonicRepository`1.Load``1(``0,System.String,System.Object)">
            <summary>
            Loads a T object
            </summary>
            <typeparam name="T"></typeparam>
            <param name="item">The item.</param>
            <param name="column">The column.</param>
            <param name="value">The value.</param>
            <returns></returns>
        </member>
        <member name="M:SubSonic.Repository.SubSonicRepository`1.Load``1(``0,System.Linq.Expressions.Expression{System.Func{``0,System.Boolean}})">
            <summary>
            Loads a T object
            </summary>
            <typeparam name="T"></typeparam>
            <param name="item">The item.</param>
            <param name="expression">The expression.</param>
            <returns></returns>
        </member>
        <member name="M:SubSonic.Repository.SubSonicRepository`1.GetAll">
            <summary>
            Returns all T items 
            </summary>
        </member>
        <member name="M:SubSonic.Repository.SubSonicRepository`1.GetByKey(System.Object)">
            <summary>
            Returns a single record 
            </summary>
        </member>
        <member name="M:SubSonic.Repository.SubSonicRepository`1.GetPaged``1(System.Func{`0,``0},System.Int32,System.Int32)">
            <summary>
            Returns a server-side Paged List 
            </summary>
        </member>
        <member name="M:SubSonic.Repository.SubSonicRepository`1.GetPaged(System.Int32,System.Int32)">
            <summary>
            Returns a server-side Paged List 
            </summary>
        </member>
        <member name="M:SubSonic.Repository.SubSonicRepository`1.GetPaged(System.String,System.Int32,System.Int32)">
            <summary>
            Returns a server-side Paged List 
            </summary>
        </member>
        <member name="M:SubSonic.Repository.SubSonicRepository`1.Search(System.String,System.String)">
            <summary>
            Returns an IQueryable  based on the passed-in Expression  Chinook Database
            </summary>
        </member>
        <member name="M:SubSonic.Repository.SubSonicRepository`1.Find(System.Linq.Expressions.Expression{System.Func{`0,System.Boolean}})">
            <summary>
            Returns an IQueryable  based on the passed-in Expression  Chinook Database
            </summary>
        </member>
        <member name="M:SubSonic.Repository.SubSonicRepository`1.Add(`0)">
            <summary>
            Adds a T item to the db
            </summary>
        </member>
        <member name="M:SubSonic.Repository.SubSonicRepository`1.Add(`0,SubSonic.DataProviders.IDataProvider)">
            <summary>
            Adds a T item to the db
            </summary>
        </member>
        <member name="M:SubSonic.Repository.SubSonicRepository`1.Add(System.Collections.Generic.IEnumerable{`0})">
             <summary>
             Adds a bunch of T items 
            </summary>
        </member>
        <member name="M:SubSonic.Repository.SubSonicRepository`1.Add(System.Collections.Generic.IEnumerable{`0},SubSonic.DataProviders.IDataProvider)">
             <summary>
             Adds a bunch of T items 
            </summary>
        </member>
        <member name="M:SubSonic.Repository.SubSonicRepository`1.Update(`0)">
            <summary>
            Updates the passed-in T 
            </summary>
        </member>
        <member name="M:SubSonic.Repository.SubSonicRepository`1.Update(`0,SubSonic.DataProviders.IDataProvider)">
            <summary>
            Updates the passed-in T 
            </summary>
        </member>
        <member name="M:SubSonic.Repository.SubSonicRepository`1.Update(System.Collections.Generic.IEnumerable{`0})">
            <summary>
            Updates the passed-in T 
            </summary>
        </member>
        <member name="M:SubSonic.Repository.SubSonicRepository`1.Update(System.Collections.Generic.IEnumerable{`0},SubSonic.DataProviders.IDataProvider)">
            <summary>
            Updates the passed-in T 
            </summary>
        </member>
        <member name="M:SubSonic.Repository.SubSonicRepository`1.Delete(System.Collections.Generic.IEnumerable{`0})">
            <summary>
            Deletes the passed-in T items 
            </summary>
        </member>
        <member name="M:SubSonic.Repository.SubSonicRepository`1.Delete(System.Collections.Generic.IEnumerable{`0},SubSonic.DataProviders.IDataProvider)">
            <summary>
            Deletes the passed-in T items 
            </summary>
        </member>
        <member name="M:SubSonic.Repository.SubSonicRepository`1.Delete(`0)">
            <summary>
            Deletes the passed-in T item 
            </summary>
        </member>
        <member name="M:SubSonic.Repository.SubSonicRepository`1.Delete(`0,SubSonic.DataProviders.IDataProvider)">
            <summary>
            Deletes the passed-in T item 
            </summary>
        </member>
        <member name="M:SubSonic.Repository.SubSonicRepository`1.Delete(System.Object)">
            <summary>
            Deletes the T item  by Primary Key
            </summary>
        </member>
        <member name="M:SubSonic.Repository.SubSonicRepository`1.Delete(System.Object,SubSonic.DataProviders.IDataProvider)">
            <summary>
            Deletes the T item  by Primary Key
            </summary>
        </member>
        <member name="M:SubSonic.Repository.SubSonicRepository`1.DeleteMany(System.Linq.Expressions.Expression{System.Func{`0,System.Boolean}})">
            <summary>
            Deletes 0 to n T items from the Database based on the passed-in Expression
            </summary>
        </member>
        <member name="M:SubSonic.Repository.SubSonicRepository`1.DeleteMany(System.Linq.Expressions.Expression{System.Func{`0,System.Boolean}},SubSonic.DataProviders.IDataProvider)">
            <summary>
            Deletes 0 to n T items from the Database based on the passed-in Expression
            </summary>
        </member>
        <member name="T:SubSonic.Query.AggregateFunction">
            <summary>
            Enum for General SQL Functions
            </summary>
        </member>
        <member name="T:SubSonic.Query.Aggregate">
            <summary>
            
            </summary>
        </member>
        <member name="M:SubSonic.Query.Aggregate.Count(SubSonic.Schema.IColumn)">
            <summary>
            Counts the specified col.
            </summary>
            <param name="col">The col.</param>
            <returns></returns>
        </member>
        <member name="M:SubSonic.Query.Aggregate.Count(SubSonic.Schema.IColumn,System.String)">
            <summary>
            Counts the specified col.
            </summary>
            <param name="col">The col.</param>
            <param name="alias">The alias.</param>
            <returns></returns>
        </member>
        <member name="M:SubSonic.Query.Aggregate.Count(System.String)">
            <summary>
            Counts the specified column name.
            </summary>
            <param name="columnName">Name of the column.</param>
            <returns></returns>
        </member>
        <member name="M:SubSonic.Query.Aggregate.Count(System.String,System.String)">
            <summary>
            Counts the specified column name.
            </summary>
            <param name="columnName">Name of the column.</param>
            <param name="alias">The alias.</param>
            <returns></returns>
        </member>
        <member name="M:SubSonic.Query.Aggregate.Sum(SubSonic.Schema.IColumn)">
            <summary>
            Sums the specified col.
            </summary>
            <param name="col">The col.</param>
            <returns></returns>
        </member>
        <member name="M:SubSonic.Query.Aggregate.Sum(System.String)">
            <summary>
            Sums the specified column name.
            </summary>
            <param name="columnName">Name of the column.</param>
            <returns></returns>
        </member>
        <member name="M:SubSonic.Query.Aggregate.Sum(SubSonic.Schema.IColumn,System.String)">
            <summary>
            Sums the specified col.
            </summary>
            <param name="col">The col.</param>
            <param name="alias">The alias.</param>
            <returns></returns>
        </member>
        <member name="M:SubSonic.Query.Aggregate.Sum(System.String,System.String)">
            <summary>
            Sums the specified column name.
            </summary>
            <param name="columnName">Name of the column.</param>
            <param name="alias">The alias.</param>
            <returns></returns>
        </member>
        <member name="M:SubSonic.Query.Aggregate.GroupBy(SubSonic.Schema.IColumn)">
            <summary>
            Groups the by.
            </summary>
            <param name="col">The col.</param>
            <returns></returns>
        </member>
        <member name="M:SubSonic.Query.Aggregate.GroupBy(System.String)">
            <summary>
            Groups the by.
            </summary>
            <param name="columnName">Name of the column.</param>
            <returns></returns>
        </member>
        <member name="M:SubSonic.Query.Aggregate.GroupBy(SubSonic.Schema.IColumn,System.String)">
            <summary>
            Groups the by.
            </summary>
            <param name="col">The col.</param>
            <param name="alias">The alias.</param>
            <returns></returns>
        </member>
        <member name="M:SubSonic.Query.Aggregate.GroupBy(System.String,System.String)">
            <summary>
            Groups the by.
            </summary>
            <param name="columnName">Name of the column.</param>
            <param name="alias">The alias.</param>
            <returns></returns>
        </member>
        <member name="M:SubSonic.Query.Aggregate.Avg(SubSonic.Schema.IColumn)">
            <summary>
            Avgs the specified col.
            </summary>
            <param name="col">The col.</param>
            <returns></returns>
        </member>
        <member name="M:SubSonic.Query.Aggregate.Avg(System.String)">
            <summary>
            Avgs the specified column name.
            </summary>
            <param name="columnName">Name of the column.</param>
            <returns></returns>
        </member>
        <member name="M:SubSonic.Query.Aggregate.Avg(SubSonic.Schema.IColumn,System.String)">
            <summary>
            Avgs the specified col.
            </summary>
            <param name="col">The col.</param>
            <param name="alias">The alias.</param>
            <returns></returns>
        </member>
        <member name="M:SubSonic.Query.Aggregate.Avg(System.String,System.String)">
            <summary>
            Avgs the specified column name.
            </summary>
            <param name="columnName">Name of the column.</param>
            <param name="alias">The alias.</param>
            <returns></returns>
        </member>
        <member name="M:SubSonic.Query.Aggregate.Max(SubSonic.Schema.IColumn)">
            <summary>
            Maxes the specified col.
            </summary>
            <param name="col">The col.</param>
            <returns></returns>
        </member>
        <member name="M:SubSonic.Query.Aggregate.Max(System.String)">
            <summary>
            Maxes the specified column name.
            </summary>
            <param name="columnName">Name of the column.</param>
            <returns></returns>
        </member>
        <member name="M:SubSonic.Query.Aggregate.Max(SubSonic.Schema.IColumn,System.String)">
            <summary>
            Maxes the specified col.
            </summary>
            <param name="col">The col.</param>
            <param name="alias">The alias.</param>
            <returns></returns>
        </member>
        <member name="M:SubSonic.Query.Aggregate.Max(System.String,System.String)">
            <summary>
            Maxes the specified column name.
            </summary>
            <param name="columnName">Name of the column.</param>
            <param name="alias">The alias.</param>
            <returns></returns>
        </member>
        <member name="M:SubSonic.Query.Aggregate.Min(SubSonic.Schema.IColumn)">
            <summary>
            Mins the specified col.
            </summary>
            <param name="col">The col.</param>
            <returns></returns>
        </member>
        <member name="M:SubSonic.Query.Aggregate.Min(System.String)">
            <summary>
            Mins the specified column name.
            </summary>
            <param name="columnName">Name of the column.</param>
            <returns></returns>
        </member>
        <member name="M:SubSonic.Query.Aggregate.Min(SubSonic.Schema.IColumn,System.String)">
            <summary>
            Mins the specified col.
            </summary>
            <param name="col">The col.</param>
            <param name="alias">The alias.</param>
            <returns></returns>
        </member>
        <member name="M:SubSonic.Query.Aggregate.Min(System.String,System.String)">
            <summary>
            Mins the specified column name.
            </summary>
            <param name="columnName">Name of the column.</param>
            <param name="alias">The alias.</param>
            <returns></returns>
        </member>
        <member name="M:SubSonic.Query.Aggregate.Variance(SubSonic.Schema.IColumn)">
            <summary>
            Variances the specified col.
            </summary>
            <param name="col">The col.</param>
            <returns></returns>
        </member>
        <member name="M:SubSonic.Query.Aggregate.Variance(System.String)">
            <summary>
            Variances the specified column name.
            </summary>
            <param name="columnName">Name of the column.</param>
            <returns></returns>
        </member>
        <member name="M:SubSonic.Query.Aggregate.Variance(SubSonic.Schema.IColumn,System.String)">
            <summary>
            Variances the specified col.
            </summary>
            <param name="col">The col.</param>
            <param name="alias">The alias.</param>
            <returns></returns>
        </member>
        <member name="M:SubSonic.Query.Aggregate.Variance(System.String,System.String)">
            <summary>
            Variances the specified column name.
            </summary>
            <param name="columnName">Name of the column.</param>
            <param name="alias">The alias.</param>
            <returns></returns>
        </member>
        <member name="M:SubSonic.Query.Aggregate.StandardDeviation(SubSonic.Schema.IColumn)">
            <summary>
            Standards the deviation.
            </summary>
            <param name="col">The col.</param>
            <returns></returns>
        </member>
        <member name="M:SubSonic.Query.Aggregate.StandardDeviation(System.String)">
            <summary>
            Standards the deviation.
            </summary>
            <param name="columnName">Name of the column.</param>
            <returns></returns>
        </member>
        <member name="M:SubSonic.Query.Aggregate.StandardDeviation(SubSonic.Schema.IColumn,System.String)">
            <summary>
            Standards the deviation.
            </summary>
            <param name="col">The col.</param>
            <param name="alias">The alias.</param>
            <returns></returns>
        </member>
        <member name="M:SubSonic.Query.Aggregate.StandardDeviation(System.String,System.String)">
            <summary>
            Standards the deviation.
            </summary>
            <param name="columnName">Name of the column.</param>
            <param name="alias">The alias.</param>
            <returns></returns>
        </member>
        <member name="M:SubSonic.Query.Aggregate.#ctor(System.String,SubSonic.Query.AggregateFunction)">
            <summary>
            Initializes a new instance of the <see cref="T:SubSonic.Query.Aggregate"/> class.
            </summary>
            <param name="columnName">Name of the column.</param>
            <param name="aggregateType">Type of the aggregate.</param>
        </member>
        <member name="M:SubSonic.Query.Aggregate.#ctor(System.String,System.String,SubSonic.Query.AggregateFunction)">
            <summary>
            Initializes a new instance of the <see cref="T:SubSonic.Query.Aggregate"/> class.
            </summary>
            <param name="columnName">Name of the column.</param>
            <param name="alias">The alias.</param>
            <param name="aggregateType">Type of the aggregate.</param>
        </member>
        <member name="M:SubSonic.Query.Aggregate.#ctor(SubSonic.Schema.IDBObject,SubSonic.Query.AggregateFunction)">
            <summary>
            Initializes a new instance of the <see cref="T:SubSonic.Query.Aggregate"/> class.
            </summary>
            <param name="column">The column.</param>
            <param name="aggregateType">Type of the aggregate.</param>
        </member>
        <member name="M:SubSonic.Query.Aggregate.#ctor(SubSonic.Schema.IDBObject,System.String,SubSonic.Query.AggregateFunction)">
            <summary>
            Initializes a new instance of the <see cref="T:SubSonic.Query.Aggregate"/> class.
            </summary>
            <param name="column">The column.</param>
            <param name="alias">The alias.</param>
            <param name="aggregateType">Type of the aggregate.</param>
        </member>
        <member name="M:SubSonic.Query.Aggregate.GetFunctionType(SubSonic.Query.Aggregate)">
            <summary>
            Gets the type of the function.
            </summary>
            <param name="agg">The agg.</param>
            <returns></returns>
        </member>
        <member name="M:SubSonic.Query.Aggregate.WithoutAlias">
            <summary>
            Gets the SQL function call without an alias.  Example: AVG(UnitPrice).
            </summary>
            <returns></returns>
        </member>
        <member name="M:SubSonic.Query.Aggregate.ToString">
            <summary>
            Overrides ToString() to return the SQL Function call
            </summary>
            <returns></returns>
        </member>
        <member name="P:SubSonic.Query.Aggregate.AggregateType">
            <summary>
            Gets or sets the type of the aggregate.
            </summary>
            <value>The type of the aggregate.</value>
        </member>
        <member name="P:SubSonic.Query.Aggregate.ColumnName">
            <summary>
            Gets or sets the name of the column.
            </summary>
            <value>The name of the column.</value>
        </member>
        <member name="P:SubSonic.Query.Aggregate.Alias">
            <summary>
            Gets or sets the alias.
            </summary>
            <value>The alias.</value>
        </member>
        <member name="T:SubSonic.Linq.Translation.RelationshipIncluder">
            <summary>
            Adds relationship to query results depending on policy
            </summary>
        </member>
        <member name="T:SubSonic.Extensions.Numeric">
            <summary>
            Summary for the Numbers class
            </summary>
        </member>
        <member name="M:SubSonic.Extensions.Numeric.IsNaturalNumber(System.String)">
            <summary>
            Determines whether a number is a natural number (positive, non-decimal)
            </summary>
            <param name="sItem">The s item.</param>
            <returns>
            	<c>true</c> if [is natural number] [the specified s item]; otherwise, <c>false</c>.
            </returns>
        </member>
        <member name="M:SubSonic.Extensions.Numeric.IsWholeNumber(System.String)">
            <summary>
            Determines whether [is whole number] [the specified s item].
            </summary>
            <param name="sItem">The s item.</param>
            <returns>
            	<c>true</c> if [is whole number] [the specified s item]; otherwise, <c>false</c>.
            </returns>
        </member>
        <member name="M:SubSonic.Extensions.Numeric.IsInteger(System.String)">
            <summary>
            Determines whether the specified s item is integer.
            </summary>
            <param name="sItem">The s item.</param>
            <returns>
            	<c>true</c> if the specified s item is integer; otherwise, <c>false</c>.
            </returns>
        </member>
        <member name="M:SubSonic.Extensions.Numeric.IsNumber(System.String)">
            <summary>
            Determines whether the specified s item is number.
            </summary>
            <param name="sItem">The s item.</param>
            <returns>
            	<c>true</c> if the specified s item is number; otherwise, <c>false</c>.
            </returns>
        </member>
        <member name="M:SubSonic.Extensions.Numeric.IsEven(System.Int32)">
            <summary>
            Determines whether the specified value is an even number.
            </summary>
            <param name="value">The value.</param>
            <returns>
            	<c>true</c> if the specified value is even; otherwise, <c>false</c>.
            </returns>
        </member>
        <member name="M:SubSonic.Extensions.Numeric.IsOdd(System.Int32)">
            <summary>
            Determines whether the specified value is an odd number.
            </summary>
            <param name="value">The value.</param>
            <returns>
            	<c>true</c> if the specified value is odd; otherwise, <c>false</c>.
            </returns>
        </member>
        <member name="M:SubSonic.Extensions.Numeric.Random(System.Int32)">
            <summary>
            Generates a random number with an upper bound
            </summary>
            <param name="high">The high.</param>
            <returns></returns>
        </member>
        <member name="M:SubSonic.Extensions.Numeric.Random(System.Int32,System.Int32)">
            <summary>
            Generates a random number between the specified bounds
            </summary>
            <param name="low">The low.</param>
            <param name="high">The high.</param>
            <returns></returns>
        </member>
        <member name="M:SubSonic.Extensions.Numeric.Random">
            <summary>
            Generates a random double
            </summary>
            <returns></returns>
        </member>
        <member name="T:SubSonic.Linq.Translation.CountOrderByRemover">
            <summary>
            Removes column declarations in SelectExpression's that are not referenced
            </summary>
        </member>
        <member name="T:SubSonic.Query.SqlQuery">
            <summary>
            
            </summary>
        </member>
        <member name="M:SubSonic.Query.SqlQuery.#ctor(SubSonic.DataProviders.IDataProvider)">
            <summary>
            Initializes a new instance of the <see cref="T:SubSonic.Query.SqlQuery"/> class.
            </summary>
            <param name="provider">The provider.</param>
        </member>
        <member name="M:SubSonic.Query.SqlQuery.ValidateQuery">
            <summary>
            Validates the query.
            </summary>
        </member>
        <member name="M:SubSonic.Query.SqlQuery.FindColumn(System.String)">
            <summary>
            Finds the column.
            </summary>
            <param name="Name">Name of the column.</param>
            <returns></returns>
        </member>
        <member name="M:SubSonic.Query.SqlQuery.Where(System.String)">
            <summary>
            Wheres the specified column name.
            </summary>
            <param name="Name">Name of the column.</param>
            <returns></returns>
        </member>
        <member name="M:SubSonic.Query.SqlQuery.Where(SubSonic.Schema.IColumn)">
            <summary>
            Wheres the specified column.
            </summary>
            <param name="column">The column.</param>
            <returns></returns>
        </member>
        <member name="M:SubSonic.Query.SqlQuery.Where(SubSonic.Query.Aggregate)">
            <summary>
            Wheres the specified agg.
            </summary>
            <param name="agg">The agg.</param>
            <returns></returns>
        </member>
        <member name="M:SubSonic.Query.SqlQuery.Or(System.String)">
            <summary>
            Ors the specified column name.
            </summary>
            <param name="Name">Name of the column.</param>
            <returns></returns>
        </member>
        <member name="M:SubSonic.Query.SqlQuery.Or(SubSonic.Schema.IColumn)">
            <summary>
            Ors the specified column.
            </summary>
            <param name="column">The column.</param>
            <returns></returns>
        </member>
        <member name="M:SubSonic.Query.SqlQuery.Or(SubSonic.Query.Aggregate)">
            <summary>
            Ors the specified agg.
            </summary>
            <param name="agg">The agg.</param>
            <returns></returns>
        </member>
        <member name="M:SubSonic.Query.SqlQuery.OrExpression(System.String)">
            <summary>
            Ors the expression.
            </summary>
            <param name="columnName">Name of the column.</param>
            <returns></returns>
        </member>
        <member name="M:SubSonic.Query.SqlQuery.OpenExpression">
            <summary>
            Opens the expression.
            </summary>
            <returns></returns>
        </member>
        <member name="M:SubSonic.Query.SqlQuery.CloseExpression">
            <summary>
            Closes the expression.
            </summary>
            <returns></returns>
        </member>
        <member name="M:SubSonic.Query.SqlQuery.And(System.String)">
            <summary>
            Ands the specified column name.
            </summary>
            <param name="Name">Name of the column.</param>
            <returns></returns>
        </member>
        <member name="M:SubSonic.Query.SqlQuery.And(SubSonic.Schema.IColumn)">
            <summary>
            Ands the specified column.
            </summary>
            <param name="column">The column.</param>
            <returns></returns>
        </member>
        <member name="M:SubSonic.Query.SqlQuery.And(SubSonic.Query.Aggregate)">
            <summary>
            Ands the specified agg.
            </summary>
            <param name="agg">The agg.</param>
            <returns></returns>
        </member>
        <member name="M:SubSonic.Query.SqlQuery.AndExpression(System.String)">
            <summary>
            Ands the expression.
            </summary>
            <param name="columnName">Name of the column.</param>
            <returns></returns>
        </member>
        <member name="M:SubSonic.Query.SqlQuery.ToString">
            <summary>
            Returns the currently set SQL statement for this query object
            </summary>
            <returns></returns>
        </member>
        <member name="M:SubSonic.Query.SqlQuery.BuildSqlStatement">
            <summary>
            Builds the SQL statement.
            </summary>
            <returns></returns>
        </member>
        <member name="M:SubSonic.Query.SqlQuery.From(SubSonic.Schema.ITable)">
            <summary>
            Froms the specified TBL.
            </summary>
            <param name="tbl">The TBL.</param>
            <returns></returns>
        </member>
        <member name="M:SubSonic.Query.SqlQuery.From(System.String)">
            <summary>
            Froms the specified TBL.
            </summary>
            <param name="tableName">Name of the table.</param>
            <returns></returns>
        </member>
        <member name="M:SubSonic.Query.SqlQuery.From``1">
            <summary>
            Froms the specified TBL.
            </summary>
            <typeparam name="T"></typeparam>
            <returns></returns>
        </member>
        <member name="M:SubSonic.Query.SqlQuery.InnerJoin``1(System.String,System.String)">
            <summary>
            Creates an inner join based on the passed-in column names
            </summary>
            <typeparam name="T"></typeparam>
            <param name="fromColumnName"></param>
            <param name="toColumnName"></param>
            <returns></returns>
        </member>
        <member name="M:SubSonic.Query.SqlQuery.InnerJoin``1">
            <summary>
            Creates an Inner Join, guessing based on Primary Key matching
            </summary>
            <typeparam name="T"></typeparam>
            <returns></returns>
        </member>
        <member name="M:SubSonic.Query.SqlQuery.InnerJoin(SubSonic.Schema.IColumn,SubSonic.Schema.IColumn)">
            <summary>
            Inners the join.
            </summary>
            <param name="fromColumn">From column.</param>
            <param name="toColumn">To column.</param>
            <returns></returns>
        </member>
        <member name="M:SubSonic.Query.SqlQuery.OuterJoin(SubSonic.Schema.IColumn,SubSonic.Schema.IColumn)">
            <summary>
            Outers the join.
            </summary>
            <param name="fromColumn">From column.</param>
            <param name="toColumn">To column.</param>
            <returns></returns>
        </member>
        <member name="M:SubSonic.Query.SqlQuery.CrossJoin(SubSonic.Schema.IColumn,SubSonic.Schema.IColumn)">
            <summary>
            Crosses the join.
            </summary>
            <param name="fromColumn">From column.</param>
            <param name="toColumn">To column.</param>
            <returns></returns>
        </member>
        <member name="M:SubSonic.Query.SqlQuery.LeftInnerJoin(SubSonic.Schema.IColumn,SubSonic.Schema.IColumn)">
            <summary>
            Lefts the inner join.
            </summary>
            <param name="fromColumn">From column.</param>
            <param name="toColumn">To column.</param>
            <returns></returns>
        </member>
        <member name="M:SubSonic.Query.SqlQuery.RightInnerJoin(SubSonic.Schema.IColumn,SubSonic.Schema.IColumn)">
            <summary>
            Rights the inner join.
            </summary>
            <param name="fromColumn">From column.</param>
            <param name="toColumn">To column.</param>
            <returns></returns>
        </member>
        <member name="M:SubSonic.Query.SqlQuery.LeftOuterJoin(SubSonic.Schema.IColumn,SubSonic.Schema.IColumn)">
            <summary>
            Lefts the outer join.
            </summary>
            <param name="fromColumn">From column.</param>
            <param name="toColumn">To column.</param>
            <returns></returns>
        </member>
        <member name="M:SubSonic.Query.SqlQuery.RightOuterJoin(SubSonic.Schema.IColumn,SubSonic.Schema.IColumn)">
            <summary>
            Rights the outer join.
            </summary>
            <param name="fromColumn">From column.</param>
            <param name="toColumn">To column.</param>
            <returns></returns>
        </member>
        <member name="M:SubSonic.Query.SqlQuery.NotEqualJoin(SubSonic.Schema.IColumn,SubSonic.Schema.IColumn)">
            <summary>
            Nots the equal join.
            </summary>
            <param name="fromColumn">From column.</param>
            <param name="toColumn">To column.</param>
            <returns></returns>
        </member>
        <member name="M:SubSonic.Query.SqlQuery.OrderAsc(System.String[])">
            <summary>
            Orders the asc.
            </summary>
            <param name="columns">The columns.</param>
            <returns></returns>
        </member>
        <member name="M:SubSonic.Query.SqlQuery.OrderDesc(System.String[])">
            <summary>
            Orders the desc.
            </summary>
            <param name="columns">The columns.</param>
            <returns></returns>
        </member>
        <member name="M:SubSonic.Query.SqlQuery.Paged(System.Int32,System.Int32)">
            <summary>
            Pageds the specified current page.
            </summary>
            <param name="currentPage">The current page.</param>
            <param name="pageSize">Size of the page.</param>
            <returns></returns>
        </member>
        <member name="M:SubSonic.Query.SqlQuery.Paged(System.Int32,System.Int32,System.String)">
            <summary>
            Pageds the specified current page.
            </summary>
            <param name="currentPage">The current page.</param>
            <param name="pageSize">Size of the page.</param>
            <param name="idColumn">The id column.</param>
            <returns></returns>
        </member>
        <member name="M:SubSonic.Query.SqlQuery.Execute">
            <summary>
            Executes this instance.
            </summary>
            <returns></returns>
        </member>
        <member name="M:SubSonic.Query.SqlQuery.ExecuteReader">
            <summary>
            Executes the reader.
            </summary>
            <returns></returns>
        </member>
        <member name="M:SubSonic.Query.SqlQuery.ExecuteScalar">
            <summary>
            Executes the scalar.
            </summary>
            <returns></returns>
        </member>
        <member name="M:SubSonic.Query.SqlQuery.ExecuteScalar``1">
            <summary>
            Executes the scalar.
            </summary>
            <typeparam name="TResult">The type of the result.</typeparam>
            <returns></returns>
        </member>
        <member name="M:SubSonic.Query.SqlQuery.GetRecordCount">
            <summary>
            Gets the record count.
            </summary>
            <returns></returns>
        </member>
        <member name="M:SubSonic.Query.SqlQuery.ExecuteTypedList``1">
            <summary>
            Executes the typed list.
            </summary>
            <typeparam name="T"></typeparam>
            <returns></returns>
        </member>
        <member name="M:SubSonic.Query.SqlQuery.ToList``1">
            <summary>
            Executes the typed list.
            </summary>
            <typeparam name="T"></typeparam>
            <returns></returns>
        </member>
        <member name="M:SubSonic.Query.SqlQuery.ExecuteSingle``1">
            <summary>
            Executes the query and returns the result as a single item of T
            </summary>
            <typeparam name="T">The type of item to return</typeparam>
        </member>
        <member name="M:SubSonic.Query.SqlQuery.ExecuteTransaction(System.Collections.Generic.List{SubSonic.Query.SqlQuery})">
            <summary>
            Executes the transaction.
            </summary>
            <param name="queries">The queries.</param>
        </member>
        <member name="M:SubSonic.Query.SqlQuery.ExecuteTransaction(System.Collections.Generic.List{SubSonic.Query.SqlQuery},System.String)">
            <summary>
            Executes the transaction.
            </summary>
            <param name="queries">The queries.</param>
            <param name="connectionStringName">Name of the connection string.</param>
        </member>
        <member name="P:SubSonic.Query.SqlQuery.OpenParenCount">
            <summary>
            Gets or sets the open paren count.
            </summary>
            <value>The open paren count.</value>
        </member>
        <member name="P:SubSonic.Query.SqlQuery.ClosedParenCount">
            <summary>
            Gets or sets the closed paren count.
            </summary>
            <value>The closed paren count.</value>
        </member>
        <member name="T:SubSonic.Query.QueryParameter">
            <summary>
            This set of classes abstracts out commands and their parameters so that
            the DataProviders can work their magic regardless of the client type. The
            System.Data.Common class was supposed to do this, but sort of fell flat
            when it came to MySQL and other DB Providers that don't implement the Data
            Factory pattern. Abstracts out the assignment of parameters, etc
            </summary>
        </member>
        <member name="P:SubSonic.Query.QueryParameter.Size">
            <summary>
            Gets or sets the size.
            </summary>
            <value>The size.</value>
        </member>
        <member name="P:SubSonic.Query.QueryParameter.Mode">
            <summary>
            Gets or sets the mode.
            </summary>
            <value>The mode.</value>
        </member>
        <member name="P:SubSonic.Query.QueryParameter.ParameterName">
            <summary>
            Gets or sets the name of the parameter.
            </summary>
            <value>The name of the parameter.</value>
        </member>
        <member name="P:SubSonic.Query.QueryParameter.ParameterValue">
            <summary>
            Gets or sets the parameter value.
            </summary>
            <value>The parameter value.</value>
        </member>
        <member name="P:SubSonic.Query.QueryParameter.DataType">
            <summary>
            Gets or sets the type of the data.
            </summary>
            <value>The type of the data.</value>
        </member>
        <member name="T:SubSonic.Query.QueryParameterCollection">
            <summary>
            Summary for the QueryParameterCollection class
            </summary>
        </member>
        <member name="M:SubSonic.Query.QueryParameterCollection.Contains(System.String)">
            <summary>
            Checks to see if specified parameter exists in the current collection
            </summary>
            <param name="parameterName"></param>
            <returns></returns>
        </member>
        <member name="M:SubSonic.Query.QueryParameterCollection.GetParameter(System.String)">
            <summary>
            returns the specified QueryParameter, if it exists in this collection
            </summary>
            <param name="parameterName"></param>
            <returns></returns>
        </member>
        <member name="M:SubSonic.Query.QueryParameterCollection.Add(System.String,System.Object)">
            <summary>
            Adds the specified parameter name.
            </summary>
            <param name="parameterName">Name of the parameter.</param>
            <param name="value">The value.</param>
        </member>
        <member name="M:SubSonic.Query.QueryParameterCollection.Add(System.String,System.Object,System.Data.DbType)">
            <summary>
            Adds the specified parameter name.
            </summary>
            <param name="parameterName">Name of the parameter.</param>
            <param name="value">The value.</param>
            <param name="dataType">Type of the data.</param>
        </member>
        <member name="M:SubSonic.Query.QueryParameterCollection.Add(System.String,System.Object,System.Data.DbType,System.Data.ParameterDirection)">
            <summary>
            Adds the specified parameter name.
            </summary>
            <param name="parameterName">Name of the parameter.</param>
            <param name="value">The value.</param>
            <param name="dataType">Type of the data.</param>
            <param name="mode">The mode.</param>
        </member>
        <member name="T:SubSonic.Query.QueryCommandCollection">
            <summary>
            Summary for the QueryCommandCollection class
            </summary>
        </member>
        <member name="T:SubSonic.Query.QueryCommand">
            <summary>
            Summary for the QueryCommand class
            </summary>
        </member>
        <member name="F:SubSonic.Query.QueryCommand.OutputValues">
            <summary>
            
            </summary>
        </member>
        <member name="M:SubSonic.Query.QueryCommand.#ctor(System.String,SubSonic.DataProviders.IDataProvider)">
            <summary>
            Initializes a new instance of the <see cref="T:SubSonic.Query.QueryCommand"/> class.
            </summary>
            <param name="sql">The SQL.</param>
            <param name="provider">The provider.</param>
        </member>
        <member name="M:SubSonic.Query.QueryCommand.HasOutputParams">
            <summary>
            Determines whether [has output params].
            </summary>
            <returns>
            	<c>true</c> if [has output params]; otherwise, <c>false</c>.
            </returns>
        </member>
        <member name="M:SubSonic.Query.QueryCommand.AddParameter(System.String,System.Object,System.Int32,System.Data.DbType,System.Data.ParameterDirection)">
            <summary>
            Adds the parameter. The public AddParameter methods should call this one.
            </summary>
            <param name="parameterName">Name of the parameter.</param>
            <param name="parameterValue">The parameter value.</param>
            <param name="maxSize">Size of the max.</param>
            <param name="dbType">Type of the db.</param>
            <param name="direction">The direction.</param>
        </member>
        <member name="M:SubSonic.Query.QueryCommand.AddParameter(System.String,System.Object,System.Data.DbType,System.Data.ParameterDirection)">
            <summary>
            Adds the parameter.
            </summary>
            <param name="parameterName">Name of the parameter.</param>
            <param name="parameterValue">The parameter value.</param>
            <param name="dataType">Type of the data.</param>
            <param name="parameterDirection">The parameter direction.</param>
        </member>
        <member name="M:SubSonic.Query.QueryCommand.AddParameter(System.String,System.Object,System.Data.DbType)">
            <summary>
            Adds the parameter.
            </summary>
            <param name="parameterName">Name of the parameter.</param>
            <param name="parameterValue">The parameter value.</param>
            <param name="dataType">Type of the data.</param>
        </member>
        <member name="M:SubSonic.Query.QueryCommand.AddParameter(System.String,System.Object)">
            <summary>
            Adds the parameter.
            </summary>
            <param name="parameterName">Name of the parameter.</param>
            <param name="parameterValue">The parameter value.</param>
        </member>
        <member name="M:SubSonic.Query.QueryCommand.AddOutputParameter(System.String,System.Int32,System.Data.DbType)">
            <summary>
            Adds the output parameter.
            </summary>
            <param name="parameterName">Name of the parameter.</param>
            <param name="maxSize">Size of the max.</param>
            <param name="dbType">Type of the db.</param>
        </member>
        <member name="M:SubSonic.Query.QueryCommand.AddOutputParameter(System.String,System.Int32)">
            <summary>
            Adds the output parameter.
            </summary>
            <param name="parameterName">Name of the parameter.</param>
            <param name="maxSize">Size of the max.</param>
        </member>
        <member name="M:SubSonic.Query.QueryCommand.AddOutputParameter(System.String)">
            <summary>
            Adds the output parameter.
            </summary>
            <param name="parameterName">Name of the parameter.</param>
        </member>
        <member name="M:SubSonic.Query.QueryCommand.AddOutputParameter(System.String,System.Data.DbType)">
            <summary>
            Adds the output parameter.
            </summary>
            <param name="parameterName">Name of the parameter.</param>
            <param name="dbType">Type of the db.</param>
        </member>
        <member name="M:SubSonic.Query.QueryCommand.AddReturnParameter">
            <summary>
            Adds a return parameter (RETURN_VALUE) to the command.
            
            </summary>
        </member>
        <member name="M:SubSonic.Query.QueryCommand.GetOutputParameters(System.Data.Common.DbCommand)">
            <summary>
            Suggested by feroalien@hotmail.com
            Issue 11 fix
            </summary>
            <param name="command"></param>
        </member>
        <member name="P:SubSonic.Query.QueryCommand.CommandTimeout">
            <summary>
            Gets or sets the command timeout (in seconds).
            </summary>
            <value>The command timeout.</value>
        </member>
        <member name="P:SubSonic.Query.QueryCommand.CommandType">
            <summary>
            Gets or sets the type of the command.
            </summary>
            <value>The type of the command.</value>
        </member>
        <member name="P:SubSonic.Query.QueryCommand.CommandSql">
            <summary>
            Gets or sets the command SQL.
            </summary>
            <value>The command SQL.</value>
        </member>
        <member name="P:SubSonic.Query.QueryCommand.Parameters">
            <summary>
            Gets or sets the parameters.
            </summary>
            <value>The parameters.</value>
        </member>
        <member name="T:SubSonic.Query.Delete`1">
            <summary>
            
            </summary>
        </member>
        <member name="M:SubSonic.Query.Delete`1.#ctor">
            <summary>
            Initializes a new instance of the <see cref="T:SubSonic.Query.Delete`1"/> class.
            </summary>
        </member>
        <member name="M:SubSonic.Query.Delete`1.#ctor(SubSonic.Schema.ITable,SubSonic.DataProviders.IDataProvider)">
            <summary>
            Initializes a new instance of the <see cref="T:SubSonic.Query.Delete`1"/> class.
            </summary>
            <param name="table">The table.</param>
            <param name="provider">The provider.</param>
        </member>
        <member name="T:SubSonic.Query.QueryType">
            <summary>
            
            </summary>
        </member>
        <member name="F:SubSonic.Query.QueryType.Select">
            <summary>
            
            </summary>
        </member>
        <member name="F:SubSonic.Query.QueryType.Update">
            <summary>
            
            </summary>
        </member>
        <member name="F:SubSonic.Query.QueryType.Insert">
            <summary>
            
            </summary>
        </member>
        <member name="F:SubSonic.Query.QueryType.Delete">
            <summary>
            
            </summary>
        </member>
        <member name="T:SubSonic.Linq.Translation.UnusedColumnRemover">
            <summary>
            Removes column declarations in SelectExpression's that are not referenced
            </summary>
        </member>
        <member name="T:SubSonic.Linq.Translation.RedundantColumnRemover">
            <summary>
            Removes duplicate column declarations that refer to the same underlying column
            </summary>
        </member>
        <member name="T:SubSonic.Linq.Translation.DeclaredAliasGatherer">
            <summary>
             returns the set of all aliases produced by a query source
            </summary>
        </member>
        <member name="T:SubSonic.Linq.Structure.ImplicitMapping">
            <summary>
            A simple query mapping that attempts to infer mapping from naming conventionss
            </summary>
        </member>
        <member name="T:SubSonic.Linq.Structure.DbExpressionWriter">
            <summary>
            Writes out an expression tree (including DbExpression nodes) in a C#-ish syntax
            </summary>
        </member>
        <member name="T:SubSonic.Extensions.RegexPattern">
            <summary>
            Summary for the RegexPattern class
            </summary>
        </member>
        <member name="M:SubSonic.Helpers.Utility.GetParameter(System.String)">
            <summary>
            Gets the parameter.
            </summary>
            <param name="sParam">The s param.</param>
            <returns></returns>
        </member>
        <member name="M:SubSonic.Helpers.Utility.GetIntParameter(System.String)">
            <summary>
            Gets the int parameter.
            </summary>
            <param name="sParam">The s param.</param>
            <returns></returns>
        </member>
        <member name="M:SubSonic.Helpers.Utility.GetGuidParameter(System.String)">
            <summary>
            Gets the GUID parameter.
            </summary>
            <param name="sParam">The s param.</param>
            <returns></returns>
        </member>
        <member name="M:SubSonic.Helpers.Utility.GetRandomString">
            <summary>
            Gets the random string.
            </summary>
            <returns></returns>
        </member>
        <member name="M:SubSonic.Helpers.Utility.RandomString(System.Int32,System.Boolean)">
            <summary>
            Randoms the string.
            </summary>
            <param name="size">The size.</param>
            <param name="lowerCase">if set to <c>true</c> [lower case].</param>
            <returns></returns>
        </member>
        <member name="M:SubSonic.Helpers.Utility.RandomInt(System.Int32,System.Int32)">
            <summary>
            Randoms the int.
            </summary>
            <param name="min">The min.</param>
            <param name="max">The max.</param>
            <returns></returns>
        </member>
        <member name="M:SubSonic.Helpers.Utility.LoadDropDown(System.Web.UI.WebControls.ListControl,System.Collections.ICollection,System.String,System.String,System.String)">
            <summary>
            Loads the drop down.
            </summary>
            <param name="ddl">The DDL.</param>
            <param name="collection">The collection.</param>
            <param name="textField">The text field.</param>
            <param name="valueField">The value field.</param>
            <param name="initialSelection">The initial selection.</param>
        </member>
        <member name="M:SubSonic.Helpers.Utility.LoadDropDown(System.Web.UI.WebControls.ListControl,System.Data.IDataReader,System.Boolean)">
            <summary>
            Loads the drop down.
            </summary>
            <param name="listControl">The list control.</param>
            <param name="dataReader">The data reader.</param>
            <param name="closeReader">if set to <c>true</c> [close reader].</param>
        </member>
        <member name="M:SubSonic.Helpers.Utility.LoadListItems(System.Web.UI.WebControls.ListItemCollection,System.Data.DataTable,System.Data.DataTable,System.String,System.String)">
            <summary>
            Loads the list items.
            </summary>
            <param name="list">The list.</param>
            <param name="tblBind">The TBL bind.</param>
            <param name="tblVals">The TBL vals.</param>
            <param name="textField">The text field.</param>
            <param name="valField">The val field.</param>
        </member>
        <member name="M:SubSonic.Helpers.Utility.LoadListItems(System.Web.UI.WebControls.ListItemCollection,System.Data.IDataReader,System.String,System.String,System.String,System.Boolean)">
            <summary>
            Loads the list items.
            </summary>
            <param name="listCollection">The list.</param>
            <param name="dataReader">The data reader.</param>
            <param name="textField">The text field.</param>
            <param name="valueField">The value field.</param>
            <param name="selectedValue">The selected value.</param>
            <param name="closeReader">if set to <c>true</c> [close reader].</param>
        </member>
        <member name="M:SubSonic.Helpers.Utility.SetListSelection(System.Web.UI.WebControls.ListItemCollection,System.String)">
            <summary>
            Sets the list selection.
            </summary>
            <param name="lc">The lc.</param>
            <param name="Selection">The selection.</param>
        </member>
        <member name="T:SubSonic.Query.Select">
            <summary>
            
            </summary>
        </member>
        <member name="M:SubSonic.Query.Select.#ctor(SubSonic.DataProviders.IDataProvider,System.String[])">
            <summary>
            Initializes a new instance of the <see cref="T:SubSonic.Query.Select"/> class.
            </summary>
            <param name="provider">The provider.</param>
            <param name="columns">The columns.</param>
        </member>
        <member name="M:SubSonic.Query.Select.#ctor">
            <summary>
            Initializes a new instance of the <see cref="T:SubSonic.Query.Select"/> class.
            </summary>
        </member>
        <member name="M:SubSonic.Query.Select.#ctor(SubSonic.Query.Aggregate[])">
            <summary>
            Initializes a new instance of the <see cref="T:SubSonic.Query.Select"/> class.
            </summary>
            <param name="aggregates">The aggregates.</param>
        </member>
        <member name="M:SubSonic.Query.Select.#ctor(SubSonic.DataProviders.IDataProvider,SubSonic.Query.Aggregate[])">
            <summary>
            Initializes a new instance of the <see cref="T:SubSonic.Query.Select"/> class.
            </summary>
            <param name="provider">The provider.</param>
            <param name="aggregates">The aggregates.</param>
        </member>
        <member name="M:SubSonic.Query.Select.#ctor(SubSonic.Schema.IColumn[])">
            <summary>
            Initializes a new instance of the <see cref="T:SubSonic.Query.Select"/> class.
            </summary>
            <param name="columns">The columns.</param>
        </member>
        <member name="M:SubSonic.Query.Select.#ctor(System.String[])">
            <summary>
            Initializes a new instance of the <see cref="T:SubSonic.Query.Select"/> class.
            WARNING: This overload should only be used with applications that use a single provider!
            </summary>
            <param name="columns">The columns.</param>
        </member>
        <member name="M:SubSonic.Query.Select.AllColumnsFrom``1">
            <summary>
            Alls the columns from.
            </summary>
            <typeparam name="T"></typeparam>
            <returns></returns>
        </member>
        <member name="M:SubSonic.Query.Select.Expression(System.String)">
            <summary>
            Expressions the specified SQL expression.
            </summary>
            <param name="sqlExpression">The SQL expression.</param>
            <returns></returns>
        </member>
        <member name="M:SubSonic.Query.Select.Top(System.String)">
            <summary>
            Tops the specified top.
            </summary>
            <param name="top">The top.</param>
            <returns></returns>
        </member>
        <member name="T:SubSonic.Query.CodingHorror">
            <summary>
            For Jeff Atwood
            http://www.codinghorror.com/blog/archives/000989.html
            </summary>
            <summary>
            A class which wraps an inline SQL call
            </summary>
        </member>
        <member name="M:SubSonic.Query.CodingHorror.#ctor(System.String)">
            <summary>
            Initializes a new instance of the <see cref="T:SubSonic.Query.CodingHorror"/> class.
            Warning: This method assumes the default provider is intended.
            Call InlineQuery(string providerName) if this is not the case.
            </summary>
            <param name="sql">The SQL.</param>
        </member>
        <member name="M:SubSonic.Query.CodingHorror.#ctor(System.String,System.Object[])">
            <summary>
            Initializes a new instance of the <see cref="T:SubSonic.Query.CodingHorror"/> class.
            </summary>
            <param name="sql">The SQL.</param>
            <param name="values">The values.</param>
        </member>
        <member name="M:SubSonic.Query.CodingHorror.#ctor(SubSonic.DataProviders.IDataProvider)">
            <summary>
            Initializes a new instance of the <see cref="T:SubSonic.Query.CodingHorror"/> class.
            </summary>
            <param name="provider">The provider.</param>
        </member>
        <member name="M:SubSonic.Query.CodingHorror.GetCommand">
            <summary>
            Gets the command.
            </summary>
            <returns></returns>
        </member>
        <member name="M:SubSonic.Query.CodingHorror.Execute">
            <summary>
            Executes the specified SQL.
            </summary>
        </member>
        <member name="M:SubSonic.Query.CodingHorror.ExecuteScalar``1">
            <summary>
            Executes the scalar.
            </summary>
            <typeparam name="TResult">The type of the result.</typeparam>
            <returns></returns>
        </member>
        <member name="M:SubSonic.Query.CodingHorror.ExecuteTypedList``1">
            <summary>
            Executes the typed list.
            </summary>
            <typeparam name="T"></typeparam>
            <returns></returns>
        </member>
        <member name="M:SubSonic.Query.CodingHorror.ExecuteReader">
            <summary>
            Executes the reader.
            </summary>
            <returns></returns>
        </member>
        <member name="T:SubSonic.Linq.Structure.IDeferLoadable">
            <summary>
            Common interface for controlling defer-loadable types
            </summary>
        </member>
        <member name="T:SubSonic.Linq.Structure.DeferredList`1">
            <summary>
            A list implementation that is loaded the first the contents are examined
            </summary>
            <typeparam name="T"></typeparam>
        </member>
        <member name="M:SubSonic.Extensions.Linq.ParseObjectValue(System.Linq.Expressions.LambdaExpression)">
            <summary>
            Parses the object value.
            </summary>
            <param name="expression">The expression.</param>
            <returns></returns>
        </member>
        <member name="M:SubSonic.Extensions.Linq.ParseConstraints(System.Linq.Expressions.Expression)">
            <summary>
            Parses the passed-in Expression into exclusive (WHERE x=y) constraints.
            </summary>
            <param name="exp">The exp.</param>
            <returns></returns>
        </member>
        <member name="M:SubSonic.Extensions.Linq.ParseConstraint(System.Linq.Expressions.LambdaExpression)">
            <summary>
            Parses the passed-in Expression into exclusive (WHERE x=y) constraint.
            </summary>
            <param name="expression">The expression.</param>
            <returns></returns>
        </member>
        <member name="M:SubSonic.Extensions.Linq.IsConstraint(System.Linq.Expressions.Expression)">
            <summary>
            Determines whether the specified exp is constraint.
            </summary>
            <param name="exp">The exp.</param>
            <returns>
            	<c>true</c> if the specified exp is constraint; otherwise, <c>false</c>.
            </returns>
        </member>
        <member name="M:SubSonic.Extensions.Linq.GetConstantValue(System.Linq.Expressions.Expression)">
            <summary>
            Gets the constant value.
            </summary>
            <param name="exp">The exp.</param>
            <returns></returns>
        </member>
        <member name="T:SubSonic.Linq.Translation.SingletonProjectionRewriter">
            <summary>
            Rewrites nested singleton projection into server-side joins
            </summary>
        </member>
        <member name="T:SubSonic.Linq.Translation.ReferencedAliasGatherer">
            <summary>
             returns the set of all aliases produced by a query source
            </summary>
        </member>
        <member name="T:SubSonic.Linq.Translation.AggregateRewriter">
            <summary>
            Rewrite aggregate expressions, moving them into same select expression that has the group-by clause
            </summary>
        </member>
        <member name="T:SubSonic.DataProviders.SharedDbConnectionScope">
            <summary>
            Indicates that a per-thread shared DbConnection object should be used the default DataProvider
            (or alternativley a specific DataProvider if one is given) when communicating with the database.
            This class is designed to be used within a using () {} block and in conjunction with a TransactionScope object.
            It's purpose is to force a common DbConnection object to be used which has the effect of avoiding promotion
            of a System.Transaction ambient Transaction to the DTC where possible.
            When this class is created, it indicates to the underlying DataProvider that is should use a shared DbConnection
            for subsequent operations. When the class is disposed (ie the using() {} block ends) it will indicate to the
            underlying provider that it should no longer it's current shared connection and should Dispose() it.
            </summary>
        </member>
        <member name="F:SubSonic.DataProviders.SharedDbConnectionScope.__instances">
            <summary>
            Used to support nesting. By keeping a stack of all instances of the class that are created on this thread
            thread we know when it is safe to Reset the underlying shared connection.
            </summary>
        </member>
        <member name="M:SubSonic.DataProviders.SharedDbConnectionScope.#ctor">
            <summary>
            Indicates to the default DataProvider that it should use a per-thread shared connection.
            </summary>
        </member>
        <member name="M:SubSonic.DataProviders.SharedDbConnectionScope.#ctor(System.String,System.String)">
            <summary>
            Indicates to the default DataProvider that it should use a per-thread shared connection using the given connection string.
            </summary>
            <param name="connectionString">The connection string.</param>
            <param name="providerName">Name of the provider.</param>
        </member>
        <member name="M:SubSonic.DataProviders.SharedDbConnectionScope.#ctor(SubSonic.DataProviders.IDataProvider)">
            <summary>
            Indicates to the specified DataProvider that it should use a per-thread shared connection.
            </summary>
            <param name="dataProvider">The data provider.</param>
        </member>
        <member name="M:SubSonic.DataProviders.SharedDbConnectionScope.Dispose">
            <summary>
            Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
            </summary>
        </member>
        <member name="M:SubSonic.DataProviders.SharedDbConnectionScope.Dispose(System.Boolean)">
            <summary>
            Releases unmanaged and - optionally - managed resources
            </summary>
            <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
        </member>
        <member name="P:SubSonic.DataProviders.SharedDbConnectionScope.CurrentConnection">
            <summary>
            Provides access to underlying connection that is shared per thread
            </summary>
            <value>The current connection.</value>
        </member>
        <member name="T:SubSonic.DataProviders.AutomaticConnectionScope">
            <summary>
            Used within SubSonic to automatically manage a SqlConnection. If a shared connection is available
            for the specified provider on the current thread, that shared connection will be used.
            Otherwise, a new connection will be created.
            Note that if a shared connection is used, it will NOT be automatically disposed - that is up to the caller.
            Lifetime management of the shared connection is taken care of by using a <see cref="T:SubSonic.DataProviders.SharedDbConnectionScope"/>
            If a new connection is created, it will be automatically disposed when this AutomaticConnectionScope object
            is disposed.
            </summary>
        </member>
        <member name="M:SubSonic.DataProviders.AutomaticConnectionScope.#ctor(SubSonic.DataProviders.IDataProvider)">
            <summary>
            Initializes a new instance of the <see cref="T:SubSonic.DataProviders.AutomaticConnectionScope"/> class.
            </summary>
            <param name="provider">The provider.</param>
        </member>
        <member name="M:SubSonic.DataProviders.AutomaticConnectionScope.Dispose">
            <summary>
            Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
            </summary>
        </member>
        <member name="M:SubSonic.DataProviders.AutomaticConnectionScope.Dispose(System.Boolean)">
            <summary>
            Releases unmanaged and - optionally - managed resources
            </summary>
            <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
        </member>
        <member name="M:SubSonic.DataProviders.AutomaticConnectionScope.GetConnection``1">
            <summary>
            Gets the connection.
            </summary>
            <typeparam name="T"></typeparam>
            <returns></returns>
        </member>
        <member name="P:SubSonic.DataProviders.AutomaticConnectionScope.Connection">
            <summary>
            Gets the connection.
            </summary>
            <value>The connection.</value>
        </member>
        <member name="P:SubSonic.DataProviders.AutomaticConnectionScope.IsUsingSharedConnection">
            <summary>
            Gets a value indicating whether this instance is using shared connection.
            </summary>
            <value>
            	<c>true</c> if this instance is using shared connection; otherwise, <c>false</c>.
            </value>
        </member>
        <member name="T:SubSonic.Linq.Structure.PartialEvaluator">
            <summary>
            Rewrites an expression tree so that locally isolatable sub-expressions are evaluated and converted into ConstantExpression nodes.
            </summary>
        </member>
        <member name="M:SubSonic.Linq.Structure.PartialEvaluator.Eval(System.Linq.Expressions.Expression,System.Func{System.Linq.Expressions.Expression,System.Boolean})">
            <summary>
            Performs evaluation and replacement of independent sub-trees
            </summary>
            <param name="expression">The root of the expression tree.</param>
            <param name="fnCanBeEvaluated">A function that decides whether a given expression node can be part of the local function.</param>
            <returns>A new tree with sub-trees evaluated and replaced.</returns>
        </member>
        <member name="M:SubSonic.Linq.Structure.PartialEvaluator.Eval(System.Linq.Expressions.Expression)">
            <summary>
            Performs evaluation and replacement of independent sub-trees
            </summary>
            <param name="expression">The root of the expression tree.</param>
            <returns>A new tree with sub-trees evaluated and replaced.</returns>
        </member>
        <member name="T:SubSonic.Linq.Structure.PartialEvaluator.SubtreeEvaluator">
            <summary>
            Evaluates and replaces sub-trees when first candidate is reached (top-down)
            </summary>
        </member>
        <member name="T:SubSonic.Linq.Structure.PartialEvaluator.Nominator">
            <summary>
            Performs bottom-up analysis to determine which nodes can possibly
            be part of an evaluated sub-tree.
            </summary>
        </member>
        <member name="M:SubSonic.SqlGeneration.SQLiteGenerator.#ctor(SubSonic.Query.SqlQuery)">
            <summary>
            Initializes a new instance of the <see cref="T:SubSonic.SqlGeneration.MySqlGenerator"/> class.
            </summary>
            <param name="query">The query.</param>
        </member>
        <member name="M:SubSonic.SqlGeneration.SQLiteGenerator.BuildPagedSelectStatement">
            <summary>
            Builds the paged select statement.
            </summary>
            <returns></returns>
        </member>
        <member name="M:SubSonic.SqlGeneration.SQLiteGenerator.BuildInsertStatement">
            <summary>
            Builds the insert statement.
            </summary>
            <returns></returns>
        </member>
        <member name="T:SubSonic.Query.ConstraintType">
            <summary>
            Where, And, Or
            </summary>
        </member>
        <member name="F:SubSonic.Query.ConstraintType.Where">
            <summary>
            WHERE operator
            </summary>
        </member>
        <member name="F:SubSonic.Query.ConstraintType.And">
            <summary>
            AND operator
            </summary>
        </member>
        <member name="F:SubSonic.Query.ConstraintType.Or">
            <summary>
            OR Operator
            </summary>
        </member>
        <member name="T:SubSonic.Query.Comparison">
            <summary>
            SQL Comparison Operators
            </summary>
        </member>
        <member name="T:SubSonic.Query.SqlComparison">
            <summary>
            Summary for the SqlComparison class
            </summary>
        </member>
        <member name="T:SubSonic.Query.Constraint">
            <summary>
            A Class for handling SQL Constraint generation
            </summary>
        </member>
        <member name="F:SubSonic.Query.Constraint.query">
            <summary>
            The query that this constraint is operating on
            </summary>
        </member>
        <member name="M:SubSonic.Query.Constraint.#ctor(SubSonic.Query.ConstraintType,System.String)">
            <summary>
            Initializes a new instance of the <see cref="T:SubSonic.Query.Constraint"/> class.
            </summary>
            <param name="condition">The condition.</param>
            <param name="constraintColumnName">Name of the constraint column.</param>
        </member>
        <member name="M:SubSonic.Query.Constraint.#ctor(SubSonic.Query.ConstraintType,System.String,System.String)">
            <summary>
            Initializes a new instance of the <see cref="T:SubSonic.Query.Constraint"/> class.
            </summary>
            <param name="condition">The condition.</param>
            <param name="constraintColumnName">Name of the constraint column.</param>
            <param name="constraintQualifiedColumnName">Name of the constraint qualified column.</param>
        </member>
        <member name="M:SubSonic.Query.Constraint.#ctor(SubSonic.Query.ConstraintType,System.String,System.String,System.String)">
            <summary>
            Initializes a new instance of the <see cref="T:SubSonic.Query.Constraint"/> class.
            </summary>
            <param name="condition">The condition.</param>
            <param name="constraintColumnName">Name of the constraint column.</param>
            <param name="constraintQualifiedColumnName">Name of the constraint qualified column.</param>
            <param name="constraintConstructionFragment">The constraint construction fragment.</param>
        </member>
        <member name="M:SubSonic.Query.Constraint.#ctor(SubSonic.Query.ConstraintType,System.String,SubSonic.Query.SqlQuery)">
            <summary>
            Initializes a new instance of the <see cref="T:SubSonic.Query.Constraint"/> class.
            </summary>
            <param name="condition">The condition.</param>
            <param name="constraintColumnName">Name of the constraint column.</param>
            <param name="sqlQuery">The SQL query.</param>
        </member>
        <member name="M:SubSonic.Query.Constraint.#ctor(SubSonic.Query.ConstraintType,System.String,System.String,System.String,SubSonic.Query.SqlQuery)">
            <summary>
            Initializes a new instance of the <see cref="T:SubSonic.Query.Constraint"/> class.
            </summary>
            <param name="condition">The condition.</param>
            <param name="constraintColumnName">Name of the constraint column.</param>
            <param name="constraintQualifiedColumnName">Name of the constraint qualified column.</param>
            <param name="constraintConstructionFragment">The constraint construction fragment.</param>
            <param name="sqlQuery">The SQL query.</param>
        </member>
        <member name="M:SubSonic.Query.Constraint.Where(System.String)">
            <summary>
            Wheres the specified column name.
            </summary>
            <param name="columnName">Name of the column.</param>
            <returns></returns>
        </member>
        <member name="M:SubSonic.Query.Constraint.And(System.String)">
            <summary>
            Ands the specified column name.
            </summary>
            <param name="columnName">Name of the column.</param>
            <returns></returns>
        </member>
        <member name="M:SubSonic.Query.Constraint.Or(System.String)">
            <summary>
            Ors the specified column name.
            </summary>
            <param name="columnName">Name of the column.</param>
            <returns></returns>
        </member>
        <member name="F:SubSonic.Query.Constraint._tableName">
            <summary>
            Gets or sets the name of the table.
            </summary>
            <value>The name of the table.</value>
        </member>
        <member name="M:SubSonic.Query.Constraint.GetComparisonOperator(SubSonic.Query.Comparison)">
            <summary>
            Gets the comparison operator.
            </summary>
            <param name="comp">The comp.</param>
            <returns></returns>
        </member>
        <member name="M:SubSonic.Query.Constraint.Equals(System.Object)">
            <summary>
            Determines whether the specified <see cref="T:System.Object"/> is equal to the current <see cref="T:System.Object"/>.
            </summary>
            <param name="obj">The <see cref="T:System.Object"/> to compare with the current <see cref="T:System.Object"/>.</param>
            <returns>
            true if the specified <see cref="T:System.Object"/> is equal to the current <see cref="T:System.Object"/>; otherwise, false.
            </returns>
            <exception cref="T:System.NullReferenceException">The <paramref name="obj"/> parameter is null.</exception>
        </member>
        <member name="M:SubSonic.Query.Constraint.GetHashCode">
            <summary>
            Serves as a hash function for a particular type.
            </summary>
            <returns>
            A hash code for the current <see cref="T:System.Object"/>.
            </returns>
        </member>
        <member name="M:SubSonic.Query.Constraint.Like(System.String)">
            <summary>
            Creates a LIKE statement.
            </summary>
            <param name="val">The val.</param>
            <returns></returns>
        </member>
        <member name="M:SubSonic.Query.Constraint.StartsWith(System.String)">
            <summary>
            Creates a LIKE statement and appends a wildcard to the end of the passed-in value.
            </summary>
            <param name="val">The val.</param>
            <returns></returns>
        </member>
        <member name="M:SubSonic.Query.Constraint.EndsWith(System.String,System.String)">
            <summary>
            Creates a LIKE statement and appends a wildcard to the end of the passed-in value.
            </summary>
            <param name="val">The val.</param>
            <param name="wildCard">The wild card.</param>
            <returns></returns>
        </member>
        <member name="M:SubSonic.Query.Constraint.EndsWith(System.String)">
            <summary>
            Creates a LIKE statement and appends a wildcard to the end of the passed-in value.
            </summary>
            <param name="val">The val.</param>
            <returns></returns>
        </member>
        <member name="M:SubSonic.Query.Constraint.NotLike(System.String)">
            <summary>
            Creates a NOT LIKE statement
            </summary>
            <param name="val">The val.</param>
            <returns></returns>
        </member>
        <member name="M:SubSonic.Query.Constraint.IsGreaterThan(System.Object)">
            <summary>
            Determines whether [is greater than] [the specified val].
            </summary>
            <param name="val">The val.</param>
            <returns></returns>
        </member>
        <member name="M:SubSonic.Query.Constraint.IsGreaterThanOrEqualTo(System.Object)">
            <summary>
            Determines whether [is greater than] [the specified val].
            </summary>
            <param name="val">The val.</param>
            <returns></returns>
        </member>
        <member name="M:SubSonic.Query.Constraint.In(SubSonic.Query.SqlQuery)">
            <summary>
            Specifies a SQL IN statement using a nested Select statement
            </summary>
            <param name="selectQuery">The select query.</param>
            <returns></returns>
        </member>
        <member name="M:SubSonic.Query.Constraint.In(System.Collections.IEnumerable)">
            <summary>
            Specifies a SQL IN statement
            </summary>
            <param name="vals">Value array</param>
            <returns></returns>
        </member>
        <member name="M:SubSonic.Query.Constraint.In(System.Object[])">
            <summary>
            Specifies a SQL IN statement
            </summary>
            <param name="vals">Value array</param>
            <returns></returns>
        </member>
        <member name="M:SubSonic.Query.Constraint.NotIn(SubSonic.Query.SqlQuery)">
            <summary>
            Specifies a SQL IN statement using a nested Select statement
            </summary>
            <param name="selectQuery">The select query.</param>
            <returns></returns>
        </member>
        <member name="M:SubSonic.Query.Constraint.NotIn(System.Collections.IEnumerable)">
            <summary>
            Specifies a SQL Not IN statement
            </summary>
            <param name="vals">Value array</param>
            <returns></returns>
        </member>
        <member name="M:SubSonic.Query.Constraint.NotIn(System.Object[])">
            <summary>
            Specifies a SQL NOT IN statement
            </summary>
            <param name="vals">Value array</param>
            <returns></returns>
        </member>
        <member name="M:SubSonic.Query.Constraint.IsLessThan(System.Object)">
            <summary>
            Determines whether [is less than] [the specified val].
            </summary>
            <param name="val">The val.</param>
            <returns></returns>
        </member>
        <member name="M:SubSonic.Query.Constraint.IsLessThanOrEqualTo(System.Object)">
            <summary>
            Determines whether [is less than] [the specified val].
            </summary>
            <param name="val">The val.</param>
            <returns></returns>
        </member>
        <member name="M:SubSonic.Query.Constraint.IsNotNull">
            <summary>
            Determines whether [is not null] [the specified val].
            </summary>
            <returns></returns>
        </member>
        <member name="M:SubSonic.Query.Constraint.IsNull">
            <summary>
            Determines whether the specified val is null.
            </summary>
            <returns></returns>
        </member>
        <member name="M:SubSonic.Query.Constraint.IsBetweenAnd(System.Object,System.Object)">
            <summary>
            Determines whether [is between and] [the specified val1].
            </summary>
            <param name="val1">The val1.</param>
            <param name="val2">The val2.</param>
            <returns></returns>
        </member>
        <member name="M:SubSonic.Query.Constraint.IsEqualTo(System.Object)">
            <summary>
            Determines whether [is equal to] [the specified val].
            </summary>
            <param name="val">The val.</param>
            <returns></returns>
        </member>
        <member name="M:SubSonic.Query.Constraint.IsNotEqualTo(System.Object)">
            <summary>
            Determines whether [is not equal to] [the specified val].
            </summary>
            <param name="val">The val.</param>
            <returns></returns>
        </member>
        <member name="P:SubSonic.Query.Constraint.Condition">
            <summary>
            Gets or sets the condition.
            </summary>
            <value>The condition.</value>
        </member>
        <member name="P:SubSonic.Query.Constraint.ColumnName">
            <summary>
            Gets or sets the name of the column.
            </summary>
            <value>The name of the column.</value>
        </member>
        <member name="P:SubSonic.Query.Constraint.QualifiedColumnName">
            <summary>
            Gets or sets the fully qualified name of the column.
            </summary>
            <value>The name of the column.</value>
        </member>
        <member name="P:SubSonic.Query.Constraint.ConstructionFragment">
            <summary>
            Gets or sets the string fragment used when assembling the text of query.
            </summary>
            <value>The construction fragment.</value>
        </member>
        <member name="P:SubSonic.Query.Constraint.Comparison">
            <summary>
            Gets or sets the comparison.
            </summary>
            <value>The comparison.</value>
        </member>
        <member name="P:SubSonic.Query.Constraint.ParameterValue">
            <summary>
            Gets or sets the parameter value.
            </summary>
            <value>The parameter value.</value>
        </member>
        <member name="P:SubSonic.Query.Constraint.StartValue">
            <summary>
            Gets or sets the start value.
            </summary>
            <value>The start value.</value>
        </member>
        <member name="P:SubSonic.Query.Constraint.EndValue">
            <summary>
            Gets or sets the end value.
            </summary>
            <value>The end value.</value>
        </member>
        <member name="P:SubSonic.Query.Constraint.InValues">
            <summary>
            Gets or sets the in values.
            </summary>
            <value>The in values.</value>
        </member>
        <member name="P:SubSonic.Query.Constraint.InSelect">
            <summary>
            Gets or sets the in select.
            </summary>
            <value>The in select.</value>
        </member>
        <member name="P:SubSonic.Query.Constraint.ParameterName">
            <summary>
            Gets or sets the name of the parameter.
            </summary>
            <value>The name of the parameter.</value>
        </member>
        <member name="P:SubSonic.Query.Constraint.DbType">
            <summary>
            Gets or sets the type of the db.
            </summary>
            <value>The type of the db.</value>
        </member>
        <member name="P:SubSonic.Query.Constraint.IsAggregate">
            <summary>
            Gets or sets a value indicating whether this constraint is an Aggregate.
            </summary>
            <value>
            	<c>true</c> if this instance is aggregate; otherwise, <c>false</c>.
            </value>
        </member>
        <member name="T:SubSonic.Linq.Translation.SelectGatherer">
            <summary>
            returns the list of SelectExpressions accessible from the source expression
            </summary>
        </member>
        <member name="T:SubSonic.Linq.Structure.ExecutionBuilder">
            <summary>
            Builds an execution plan for a query expression
            </summary>
        </member>
        <member name="T:SubSonic.Linq.Structure.ExecutionBuilder.OuterParameterizer">
            <summary>
            columns referencing the outer alias are turned into special named-value parameters
            </summary>
        </member>
        <member name="M:SubSonic.SqlGeneration.Schema.Sql2005Schema.BuildDropColumnStatement(System.String,System.String)">
            <summary>
            Removes the column.
            </summary>
            <param name="tableName"></param>
            <param name="columnName"></param>
            <returns></returns>
        </member>
        <member name="M:SubSonic.SqlGeneration.Schema.Sql2005Schema.GenerateColumnAttributes(SubSonic.Schema.IColumn)">
            <summary>
            Sets the column attributes.
            </summary>
            <param name="column">The column.</param>
            <returns></returns>
        </member>
        <member name="M:SubSonic.SqlGeneration.Schema.Sql2005Schema.GetDbType(System.String)">
            <summary>
            Gets the type of the db.
            </summary>
            <param name="sqlType">Type of the SQL.</param>
            <returns></returns>
        </member>
        <member name="M:SubSonic.Schema.Migrator.CreateColumnMigrationSql(SubSonic.Schema.ITable)">
            <summary>
             Creates a set of SQL commands for synchronizing your database with your object set
            </summary>
        </member>
        <member name="T:SubSonic.Linq.Translation.ClientJoinedProjectionRewriter">
            <summary>
            rewrites nested projections into client-side joins
            </summary>
        </member>
        <member name="T:SubSonic.Linq.Structure.QueryPolicy">
            <summary>
            Defines query execution and materialization policies. 
            </summary>
        </member>
        <member name="M:SubSonic.Linq.Structure.QueryPolicy.IsIncluded(System.Reflection.MemberInfo)">
            <summary>
            Determines if a relationship property is to be included in the results of the query
            </summary>
            <param name="member"></param>
            <returns></returns>
        </member>
        <member name="M:SubSonic.Linq.Structure.QueryPolicy.IsDeferLoaded(System.Reflection.MemberInfo)">
            <summary>
            Determines if a relationship property is included, but the query for the related data is 
            deferred until the property is first accessed.
            </summary>
            <param name="member"></param>
            <returns></returns>
        </member>
        <member name="M:SubSonic.Linq.Structure.QueryPolicy.Translate(System.Linq.Expressions.Expression)">
            <summary>
            Provides policy specific query translations.  This is where choices about inclusion of related objects and how
            heirarchies are materialized affect the definition of the queries.
            </summary>
            <param name="expression"></param>
            <returns></returns>
        </member>
        <member name="M:SubSonic.Linq.Structure.QueryPolicy.BuildExecutionPlan(System.Linq.Expressions.Expression,System.Linq.Expressions.Expression)">
            <summary>
            Converts a query into an execution plan.  The plan is an function that executes the query and builds the
            resulting objects.
            </summary>
            <param name="projection"></param>
            <param name="provider"></param>
            <returns></returns>
        </member>
        <member name="P:SubSonic.Linq.Structure.QueryPolicy.Mapping">
            <summary>
            The mapping related to the policy.
            </summary>
        </member>
    </members>
</doc>