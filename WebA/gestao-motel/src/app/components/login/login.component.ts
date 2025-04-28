import { Component } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from '../../auth/auth.service';

@Component({ selector: 'app-login', templateUrl: './login.component.html' })
export class LoginComponent {
  form = this.fb.group({
    email: ['', [Validators.required, Validators.email]],
    password: ['', [Validators.required]]
  });

  error: string | null = null;

  constructor(private fb: FormBuilder, private auth: AuthService, private router: Router) {}

  submit() {
    if (this.form.invalid) return;
    this.auth.login(this.form.value.email!, this.form.value.password!)
      .subscribe({
        next: () => this.router.navigate(['/claims']),
        error: err => this.error = err.error
      });
  }
}