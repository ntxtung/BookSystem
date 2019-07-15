import React from 'react'

import { Button, Form, Segment } from 'semantic-ui-react'
import {connect} from 'react-redux'
import {doAuthLogin} from '../actions'

class LoginForm extends React.Component {
  constructor(props){
    super(props)
    this.state = {
      isFetching: false,
      authData: {
        username: '',
        password: ''
      }
    }
  }

  onFormSubmit = (e) => {
    e.preventDefault();
    this.setState({isFetching: true})
    this.props.doAuthLogin(this.state.authData)
  }

  updateUsername = (data) => {
    this.setState(prevState => ({
      ...prevState,
      authData: {
        ...prevState.authData,
        username: data}
      })
    )
  }

  updatePassword = (data) => {
    this.setState(prevState => ({
      ...prevState,
      authData: {
        ...prevState.authData,
        password: data}
      })
    )
  }

  render() {
    return (
      <Form size='large' loading={this.state.isFetching} onSubmit={this.onFormSubmit}>
        <Segment stacked>
          <Form.Input
            fluid
            icon='user'
            iconPosition='left'
            placeholder='Username'
            onChange = {(event, data) => 
              this.updateUsername(data.value)
            }
          />
          <Form.Input
            fluid
            icon='lock'
            iconPosition='left'
            placeholder='Password'
            type='password'
            onChange = {(event, data) => 
              this.updatePassword(data.value)
            }
          />

          <Button color='orange' fluid size='large'>
            Login
          </Button>
        </Segment>
      </Form>
    )
  }
}

const mapStateToProps = (state) => {
  return {
  };
}

export default connect(mapStateToProps, {doAuthLogin})(LoginForm)