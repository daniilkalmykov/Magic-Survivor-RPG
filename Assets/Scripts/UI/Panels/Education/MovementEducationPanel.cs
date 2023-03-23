using UnityEngine;

namespace UI.Panels.Education
{
    public sealed class MovementEducationPanel : EducationPanel
    {
        [SerializeField] private ExperienceEducationPanel _experienceEducationPanel;

        protected override void OnEnable()
        {
            base.OnEnable();
            _experienceEducationPanel.gameObject.SetActive(false);
        }

        protected override void OnDisable()
        {
            base.OnDisable();
            _experienceEducationPanel.gameObject.SetActive(true);
        }
    }
}