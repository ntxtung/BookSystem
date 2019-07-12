import React from 'react'
import { Grid, Header, Image, Message, Label } from 'semantic-ui-react'
import LoginForm from '../components/LoginForm'
import SignUpForm from '../components/SignUpForm'
import { connect } from 'react-redux'
import { Redirect } from 'react-router';

class AuthPage extends React.Component {
  constructor(props) {
    super(props)
    this.state = {
      isLogin: true
    }
  }

  formRender = () => {
    if (this.state.isLogin) {
      return (
        <LoginForm />
      )
    } else {
      return (
        <SignUpForm />
      )
    }
  }

  render() {
    if (this.props.loggedInUser === null){
      return (
        <Grid textAlign='center'
          style={{
            height: '100vh',
            paddingTop: '10vh',
            backgroundImage: "url(" + process.env.PUBLIC_URL + "authBackground2.jpg" + ")",
            backgroundPosition: 'center',
            backgroundSize: 'cover',
            backgroundRepeat: 'no-repeat'
          }}
          verticalAlign='top'>
          <Grid.Column style={{ maxWidth: 450 }}>

            <Image size="small" centered src={process.env.PUBLIC_URL + '/Logo-full.png'} />
            <Header as='h2' color='orange' textAlign='center'>
              Book Rent System
          </Header>

            {this.formRender()}

            <Message>
              {this.state.isLogin ? 'New to us? ' : 'Already us? '}
              <Label as='a'
                onClick={() => this.setState({ isLogin: !this.state.isLogin })}>
                {this.state.isLogin ? 'Sign Up' : 'Sign In'}
              </Label>
            </Message>

          </Grid.Column>
        </Grid>
      )
    } else {
      return (
        <Redirect push to="/" />
      )
    }
       
  }
}

const mapStateToProps = (state) => {
  return {
    loggedInUser: state.loggedInUser
  };
}

export default connect(mapStateToProps, {})(AuthPage)