/* 
 * Copyright (C) 2014 Mehdi El Gueddari
 * http://mehdi.me
 *
 * This software may be modified and distributed under the terms
 * of the MIT license.  See the LICENSE file for details.
 */

using System;
using System.Data;
using SmartFleet.Core.Data;
using SmartFleet.Core.Data.Enums;

namespace SmartFleet.Data.Dbcontextccope.Implementations
{
    public class DbContextScopeFactory : IDbContextScopeFactory
    {
        private readonly IDbContextFactory _dbContextFactory;

        public DbContextScopeFactory(IDbContextFactory dbContextFactory = null)
        {
            _dbContextFactory = dbContextFactory;
        }

       

        public IDbContextScope Create(DbContextScopeOption joiningOption)
        {
            return new DbContextScope(
                joiningOption: joiningOption,
                readOnly: false,
                isolationLevel: null,
                dbContextFactory: _dbContextFactory);
        }

        public IDbContextReadOnlyScope CreateReadOnly(DbContextScopeOption joiningOption)
        {
            return new DbContextReadOnlyScope(
                joiningOption: joiningOption,
                isolationLevel: null,
                dbContextFactory: _dbContextFactory);
        }

        public IDbContextScope CreateWithTransaction(IsolationLevel isolationLevel)
        {
            return new DbContextScope(
                joiningOption: DbContextScopeOption.ForceCreateNew, 
                readOnly: false, 
                isolationLevel: isolationLevel, 
                dbContextFactory: _dbContextFactory);
        }

        public IDbContextReadOnlyScope CreateReadOnlyWithTransaction(IsolationLevel isolationLevel)
        {
            return new DbContextReadOnlyScope(
                joiningOption: DbContextScopeOption.ForceCreateNew, 
                isolationLevel: isolationLevel, 
                dbContextFactory: _dbContextFactory);
        }

        public IDisposable SuppressAmbientContext()
        {
            return new AmbientContextSuppressor();
        }

       
    }
}