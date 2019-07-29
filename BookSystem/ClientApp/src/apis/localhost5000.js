import axios from 'axios'

export default axios.create({
    baseURL: 'http://localhost:5000/api',
    headers: {
        Authorization: 'Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJJZCI6IjEiLCJVc2VybmFtZSI6Im50eHR1bmciLCJqdGkiOiJkZTgxNTA2ZS04ZjQzLTRkMzAtOTQ4NC00NWVjOTVhM2Y5ZDIiLCJodHRwOi8vc2NoZW1hcy5taWNyb3NvZnQuY29tL3dzLzIwMDgvMDYvaWRlbnRpdHkvY2xhaW1zL3JvbGUiOiJBZG1pbiIsImV4cCI6MTU2Mzk3MTE5MSwiaXNzIjoiVGhlRnVja2luZ0pXVC5jb20iLCJhdWQiOiJUaGVGdWNraW5nSldULmNvbSJ9.S54gcAvKSMPsAM_RO-lpjvV6k8a2HX6GI-D8IgNs5ak'
    }
})