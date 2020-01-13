Imports DevExpress.XtraTreeList
Imports DevExpress.XtraTreeList.Columns

' Represents a sample Business Object. 
Public Class MyData
    Implements TreeList.IVirtualTreeListData
    Protected parentCore As MyData
    Protected childrenCore As New ArrayList()
    Protected cellsCore() As Object


    Public Sub New(ByVal parent As MyData, ByVal cells() As Object)
        ' Specifies the parent node for the new node. 
        Me.parentCore = parent
        ' Provides data for the node's cell. 
        Me.cellsCore = cells
        If Not (Me.parentCore Is Nothing) Then
            Me.parentCore.childrenCore.Add(Me)
        End If
    End Sub

    Sub VirtualTreeGetChildNodes(ByVal info As VirtualTreeGetChildNodesInfo) _
    Implements TreeList.IVirtualTreeListData.VirtualTreeGetChildNodes
        info.Children = childrenCore
    End Sub

    Sub VirtualTreeGetCellValue(ByVal info As VirtualTreeGetCellValueInfo) _
    Implements TreeList.IVirtualTreeListData.VirtualTreeGetCellValue
        info.CellData = cellsCore(info.Column.AbsoluteIndex)
    End Sub

    Sub VirtualTreeSetCellValue(ByVal info As VirtualTreeSetCellValueInfo) _
    Implements TreeList.IVirtualTreeListData.VirtualTreeSetCellValue
        cellsCore(info.Column.AbsoluteIndex) = info.NewCellData
    End Sub

End Class