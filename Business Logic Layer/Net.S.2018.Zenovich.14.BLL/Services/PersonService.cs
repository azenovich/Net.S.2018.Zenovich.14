﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Net.S._2018.Zenovich._14.BLL.Configuration;
using Net.S._2018.Zenovich._14.BLL.Services.Interfaces;
using Net.S._2018.Zenovich._14.DAL.Models;
using Net.S._2018.Zenovich._14.DAL.Repositories.Interfaces;
using Net.S._2018.Zenovich._14.PL.ViewModels.Account;
using Net.S._2018.Zenovich._14.PL.ViewModels.Person;
using Ninject;

namespace Net.S._2018.Zenovich._14.BLL.Services
{
    public class PersonService : IPersonService
    {
        private IAccountRepository _accountRepository;
        private IPeopleRepository _peopleRepository;

        public PersonService(IUnitOfWork unitOfWork)
        {
            _accountRepository = unitOfWork.AccountRepository;
            _peopleRepository = unitOfWork.PeopleRepository;
        }

        public void Add(RegisterViewModel vm)
        {
            if (vm == null)
            {
                throw new ArgumentNullException(nameof(vm));
            }

            var account = Mapper.Map<RegisterViewModel, Account>(vm);
            _accountRepository.Add(account);
        }

        public IEnumerable<PersonViewModel> GetAll()
        {
            var ienumerable = _peopleRepository.GetAll();
            IEnumerable<PersonViewModel> people = Mapper.Map<IEnumerable<Person>, List<PersonViewModel>>(ienumerable);
            return people;
        }

        public PersonViewModel Get(Guid id)
        {
            if (id == null)
            {
                throw new ArgumentNullException(nameof(id));
            }

            var person = Mapper.Map<Person, PersonViewModel>(_peopleRepository.Get(id));

            return person;
        }

        public IEnumerable<AccountViewModel> GetClientAccounts(Guid id)
        {
            if (id == null)
            {
                throw new ArgumentNullException(nameof(id));
            }

            var person = _peopleRepository.Get(id);

            if (person != null)
            {
                var accounts = Mapper.Map<IEnumerable<Account>, List<AccountViewModel>>(person.Accounts);
                return accounts;
            }
            
            return null;
        }
    }
}