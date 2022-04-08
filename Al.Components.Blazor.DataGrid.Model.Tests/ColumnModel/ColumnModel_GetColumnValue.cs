﻿using Al.Components.Blazor.DataGrid.Tests.Data;

using Xunit;

namespace Al.Components.Blazor.DataGrid.Model.Tests
{
    public class ColumnModel_GetColumnValue
    {
        [Fact]
        public void ExpressionNull_ReturnNull()
        {
            //arrange
            var user = new User()
            {
                Id = 1,
                FirstName = "lsdkjf"
            };
            var column = new ColumnModel<User>("dslfsk");

            //act
            var value = column.GetColumnValue(user);

            //assert
            Assert.Null(value);
        }

        [Fact]
        public void ExpressionNotNull_ReturnNotNull()
        {
            //arrange
            var user = new User()
            {
                Id = 1,
                FirstName = "lsdkjf"
            };
            var column = new ColumnModel<User>(x => x.Id);

            //act
            var value = column.GetColumnValue(user);

            //assert
            Assert.NotNull(value);
        }
    }
}
