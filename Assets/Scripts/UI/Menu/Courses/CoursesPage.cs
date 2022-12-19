using System;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Menu.Courses
{
    public class CoursesPage : PageBase
    {
        [SerializeField] private CourseView _courseViewPrefab;
        [SerializeField] private Transform _container;

        public override void Init()
        {
            base.Init();
            for (int i = 0; i < 10; i++)
            {
                var course = Instantiate(_courseViewPrefab, _container);
                course.Init(i);
            }
        }
    }
}
