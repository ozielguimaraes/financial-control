﻿namespace FinancialControl.Domain.Entities
{
    public class User
    {
        public long UserId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public bool Active { get; set; }

        public void Update(User userUpdated)
        {
            //TODO Update properties
        }
    }
}
