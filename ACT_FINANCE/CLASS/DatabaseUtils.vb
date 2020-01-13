Imports System.Linq.Expressions
Imports System.Data.Linq.Mapping
Imports System.Data.Linq
Imports System.Linq

Public Class DatabaseUtils

    Public Shared Function CreateTbl(Of T)() As DataTable
        Dim tbl As New DataTable
        Dim properties() As Reflection.PropertyInfo

        properties = GetType(T).GetProperties()

        For Each p As Reflection.PropertyInfo In properties
            tbl.Columns.Add(p.Name, If(Nullable.GetUnderlyingType(p.PropertyType), p.PropertyType))

            If p.PropertyType = GetType(Nullable(Of Boolean)) Then
                tbl.Columns(p.Name).DefaultValue = False
            ElseIf p.PropertyType = GetType(Nullable(Of Long)) Or
                p.PropertyType = GetType(Nullable(Of Decimal)) Or
                p.PropertyType = GetType(Nullable(Of Double)) Or
                p.PropertyType = GetType(Nullable(Of Short)) Or
                p.PropertyType = GetType(Nullable(Of Byte)) Then

                tbl.Columns(p.Name).DefaultValue = 0
            ElseIf p.PropertyType = GetType(String) Then
                tbl.Columns(p.Name).DefaultValue = ""
            End If
        Next

        Return tbl
    End Function

    Public Shared Sub SaveChanges(Of T As {Class, New})(ByVal objTbl As DataTable, ByVal db As DataClassesFRMDataContext)
        Dim tbl_New As DataTable
        Dim tbl_Modified As DataTable
        Dim tbl_Delete As DataTable
        Dim entity As T
        Dim entityType As Type = GetType(T)
        Dim metaEntityType As MetaType = db.Mapping.GetMetaType(entityType)
        Dim primaryKeysColumns As IEnumerable(Of MetaDataMember) = metaEntityType.DataMembers.Where(Function(p) p.IsPrimaryKey)
        Dim table As Table(Of T) = db.GetTable(Of T)()
        Dim paramExpression As ParameterExpression = Expression.Parameter(entityType, "entity")

        tbl_New = objTbl.GetChanges(DataRowState.Added)
        tbl_Modified = objTbl.GetChanges(DataRowState.Modified)
        tbl_Delete = objTbl.GetChanges(DataRowState.Deleted)

        If tbl_New IsNot Nothing Then
            For Each row As DataRow In tbl_New.Rows
                Dim prop() As Reflection.PropertyInfo

                entity = New T

                prop = entity.GetType.GetProperties()

                For Each h As Reflection.PropertyInfo In prop
                    If objTbl.Columns.Contains(h.Name) Then
                        h.SetValue(entity, clsUtil.IsDbNull(row.Item(h.Name), Nothing), Nothing)
                    End If
                Next

                table.InsertOnSubmit(entity)
                db.SubmitChanges()
            Next
        End If

        If tbl_Modified IsNot Nothing Then
            Dim whereExpression As BinaryExpression = Nothing
            Dim condition As BinaryExpression
            Dim predicate As Expression(Of Func(Of T, Boolean))

            For Each row As DataRow In tbl_Modified.Rows
                whereExpression = Nothing

                For Each pkColumn As MetaDataMember In primaryKeysColumns
                    Dim val = row.Item(pkColumn.Name, DataRowVersion.Original)

                    condition = Expression.Equal(Expression.Property(paramExpression, pkColumn.Name), Expression.Constant(val))

                    If whereExpression IsNot Nothing Then
                        whereExpression = Expression.And(whereExpression, condition)
                    Else
                        whereExpression = condition
                    End If
                Next

                predicate = Expression.Lambda(Of Func(Of T, Boolean))(whereExpression, New ParameterExpression() {paramExpression})

                entity = table.SingleOrDefault(predicate)

                For Each h As Reflection.PropertyInfo In entity.GetType.GetProperties
                    If objTbl.Columns.Contains(h.Name) Then
                        h.SetValue(entity, clsUtil.IsDbNull(row.Item(h.Name), Nothing), Nothing)
                    End If
                Next

                db.SubmitChanges()
            Next
        End If

        If tbl_Delete IsNot Nothing Then
            Dim whereExpression As BinaryExpression = Nothing
            Dim condition As BinaryExpression
            Dim predicate As Expression(Of Func(Of T, Boolean))

            For Each row As DataRow In tbl_Delete.Rows
                whereExpression = Nothing

                For Each pkColumn As MetaDataMember In primaryKeysColumns
                    Dim val = row.Item(pkColumn.Name, DataRowVersion.Original)

                    condition = Expression.Equal(Expression.Property(paramExpression, pkColumn.Name), Expression.Constant(val))

                    If whereExpression IsNot Nothing Then
                        whereExpression = Expression.And(whereExpression, condition)
                    Else
                        whereExpression = condition
                    End If
                Next

                predicate = Expression.Lambda(Of Func(Of T, Boolean))(whereExpression, New ParameterExpression() {paramExpression})

                entity = table.SingleOrDefault(predicate)

                table.DeleteOnSubmit(entity)
                db.SubmitChanges()
            Next
        End If
    End Sub

    Public Shared Sub DataFill(Of T)(ByRef objTbl As DataTable, ByVal query As IQueryable(Of T))
        Dim properties() As Reflection.PropertyInfo
        Dim newRow As DataRow

        For Each p As T In query
            properties = p.GetType.GetProperties

            newRow = objTbl.NewRow()

            For Each h As Reflection.PropertyInfo In properties
                If objTbl.Columns.Contains(h.Name) Then
                    newRow.Item(h.Name) = clsUtil.IsDbNull(h.GetValue(p, Nothing), DBNull.Value)
                End If
            Next

            objTbl.Rows.Add(newRow)
        Next

        objTbl.AcceptChanges()
    End Sub

    Public Shared Sub DataFill(Of T)(ByRef objTbl As DataTable, ByVal generic As IEnumerator(Of T))
        Dim properties() As Reflection.PropertyInfo
        Dim result As T
        Dim newRow As DataRow

        While generic.MoveNext
            result = generic.Current
            properties = result.GetType.GetProperties

            newRow = objTbl.NewRow()

            For Each h As Reflection.PropertyInfo In properties
                If objTbl.Columns.Contains(h.Name) Then
                    newRow.Item(h.Name) = clsUtil.IsDbNull(h.GetValue(result, Nothing), DBNull.Value)
                End If
            Next

            objTbl.Rows.Add(newRow)
        End While

    End Sub
End Class
