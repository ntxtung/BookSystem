import React from 'react'

import { Button, Form, Segment, StepTitle } from 'semantic-ui-react'
import {connect} from 'react-redux'
import {doAuthLogin} from '../actions'

class LoginForm extends React.Component {
  constructor(props){
    super(props)
    this.state = {
      username: '',
      password: ''
    }
  }

  onFormSubmit = (e) => {
    e.preventDefault();
    this.props.doAuthLogin(this.state)
  }

  render() {
    return (
      <Form size='large' onSubmit={this.onFormSubmit}>
        <Segment stacked>
          <Form.Input
            fluid
            icon='user'
            iconPosition='left'
            placeholder='Username'
            onChange = {(event, data) => this.setState({username: data.value})}
          />
          <Form.Input
            fluid
            icon='lock'
            iconPosition='left'
            placeholder='Password'
            type='password'
            onChange = {(event, data) => this.setState({password: data.value})}
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