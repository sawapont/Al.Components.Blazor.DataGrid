﻿using Al.Components.Blazor.DataGrid.Tests.Data;
using Al.Components.Blazor.DataGrid.TestsData;

using System;
using System.Threading.Tasks;

using Xunit;

namespace Al.Components.Blazor.DataGrid.Model.Tests.ColumnsModel
{
    public class ColumnsModel_DragColumnEnd
    {
        [Fact]
        public async Task DropSelf_DraggingColumnNullAndNotEventCall()
        {
            //arrange
            bool callEvent = false;
            ColumnsModel<User> columns = Models.AddColumns(new() { Draggable = true });
            Func<ColumnModel<User>, Task> eventHandler = async (x) => callEvent = true;
            EventTest<ColumnsModel<User>> eventTest = new(columns, nameof(columns.OnDragEnd), eventHandler);
            var column2 = columns.All[1].Value;
            await columns.DragColumnStart(column2);

            //act
            await columns.DragColumnEnd(column2, true);

            //assert
            Assert.Null(columns.DraggingColumn);
            Assert.False(callEvent);
        }


        [Fact]
        public async Task DropBeforeNotSelf_DraggingColumnNullAndEventCallAndColumnBefore()
        {
            //arrange
            bool callEvent = false;
            ColumnsModel<User> columns = Models.AddColumns(new() { Draggable = true });
            Func<ColumnModel<User>, Task> eventHandler = async (x) => callEvent = true;
            EventTest<ColumnsModel<User>> eventTest = new(columns, nameof(columns.OnDragEnd), eventHandler);
            var column1node = columns.All[0];
            var column2node = columns.All[1];
            await columns.DragColumnStart(column2node.Value);

            //act
            await columns.DragColumnEnd(column1node.Value, true);

            //assert
            Assert.Null(columns.DraggingColumn);
            Assert.True(callEvent);
            Assert.True(column1node.Index - 1 == column2node.Index);
        }

        [Fact]
        public async Task DropAfterNotSelf_DraggingColumnNullAndEventCallAndColumnBefore()
        {
            //arrange
            bool callEvent = false;
            ColumnsModel<User> columns = Models.AddColumns(new() { Draggable = true });
            Func<ColumnModel<User>, Task> eventHandler = async (x) => callEvent = true;
            EventTest<ColumnsModel<User>> eventTest = new(columns, nameof(columns.OnDragEnd), eventHandler);
            var column3node = columns.All[0];
            var column2node = columns.All[1];
            await columns.DragColumnStart(column2node.Value);

            //act
            await columns.DragColumnEnd(column3node.Value, false);

            //assert
            Assert.Null(columns.DraggingColumn);
            Assert.True(callEvent);
            Assert.True(column2node.Index - 1 == column3node.Index);
        }
    }
}