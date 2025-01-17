using System;

namespace FitnessApp.BL.Model
{
    /// <summary>
    /// Пользователь.
    /// </summary>
    public class User
    {
        private const double MIN_WEIGHT = 0;
        private const double MIN_HEIGHT = 0;

        private readonly DateTime MIN_BIRTHDATE = new DateTime(1900, 1, 1);

        #region Свойства
        /// <summary>
        /// Имя.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Пол.
        /// </summary>
        public Gender Gender { get; }

        /// <summary>
        /// Дата рождения.
        /// </summary>
        public DateTime Birthdate { get; }

        /// <summary>
        /// Вес.
        /// </summary>
        public double Weight { get; set; }

        /// <summary>
        /// Рост.
        /// </summary>
        public double Height { get; set; }
        #endregion

        /// <summary>
        /// Создать нового пользователя.
        /// </summary>
        /// <param name="name"> Имя. </param>
        /// <param name="gender"> Пол. </param>
        /// <param name="birthdate"> Дата рождения. </param>
        /// <param name="weight"> Вес. </param>
        /// <param name="height"> Рост. </param>
        public User(string name, Gender gender, DateTime birthdate, double weight, double height)
        {
            #region Проверка условий
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException("Имя пользователя не может быть пустым или null.", nameof(name));

            if (gender == null)
                throw new ArgumentNullException("Пол не может быть null.", nameof(gender));

            if (birthdate < MIN_BIRTHDATE || birthdate >= DateTime.Now)
                throw new ArgumentException("невозможная дата рождения.", nameof(birthdate));

            if (weight <= MIN_WEIGHT)
                throw new ArgumentException($"Вес не может быть меньше или равен {MIN_WEIGHT}.", nameof(weight));

            if (height <= MIN_HEIGHT)
                throw new ArgumentException($"Рост не может быть меньше или равен {MIN_HEIGHT}.", nameof(weight));
            #endregion

            Name = name;
            Gender = gender;
            Birthdate = birthdate;
            Weight = weight;
            Height = height;
        }

        public override string ToString() => Name;
    }
}
