import { createRouter, createWebHashHistory } from 'vue-router'
import AddSubjectView from './components/AddSubject/AddSubjectView.vue'
import ExamView from './components/Exam/ExamView.vue'
import MainPageView from './components/MainPageView.vue'
import ManageView from './components/ManageView.vue'
import ManageSubjectView from './components/ManageSubject/ManageSubjectView.vue'
import UpdateSubjectView from './components/ManageSubject/UpdateSubjectView.vue'
import SubjectWithCorrectAnswersView from './components/SubjectAnswers/SubjectWithCorrectAnswersView.vue'
import SubjectView from './components/SubjectAnswers/SubjectView.vue'
export default createRouter({
  history: createWebHashHistory(),
  routes: [
    { path: '/', component: MainPageView },
    {
      path: '/subject',
      component: SubjectView
    },
    { path: '/subject/:id', component: SubjectWithCorrectAnswersView, name: 'subject' },
    { path: '/subject/takeexam/:id', component: ExamView, name: 'exam' },
    {
      path: '/manage',
      component: ManageView,
      children: [
        { path: '/manage/addsubject', component: AddSubjectView },
        { path: '/manage/managesubjects', component: ManageSubjectView },
        { path: '/manage/managesubjects/:id', component: UpdateSubjectView, name: 'manage-subject' }
      ]
    }
  ]
})
